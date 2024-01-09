using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawnerScript groundSpawnerScript;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    public float spawnInterval = 2f;

   /*private float timer;*/


    private void Start()
    {
        groundSpawnerScript = GameObject.FindObjectOfType<GroundSpawnerScript>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawnerScript.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
   
    public void SpawnCoins()
    {
        int coinsToSpawn = 1;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

           
        }
    }

    /*public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoins();
            timer = 0f;
        }
    }*/

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}