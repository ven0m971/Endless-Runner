using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    playerController PlayerController;
  
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.FindObjectOfType<playerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerController.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
