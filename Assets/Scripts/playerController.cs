using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[SerializeField]
public enum side { left,mid,right};
public class playerController : MonoBehaviour
    
{
    Animator animator;
    public side Side=side.mid;
    public float speed = 1.0f;
    /*float posVal = 0;
    float PosValueY = 0;*/
    [SerializeField] Rigidbody rb;
    bool alive = true;
    public float speedIncreasePerPoint = 0.1f;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask GroundMask;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
      if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove+horizontalMove);
    }
    void Start()
    {
        transform.position = Vector3.zero;  
    }

    // Update is called once per frame
    
     void Update()
    {
        /* Vector3 pos = Input.mousePosition;
         Vector3 t = Camera.main.ScreenToViewportPoint(pos);*/


        /* if (Input.GetMouseButton(0))
         {
             if(t.x < 0)
             {
                 posVal = -4;
             }
             else if(t.x >= 0 && t.x <= 1)
             {
                 posVal = 0;
             }
             else if(t.x > 1)
             {
                 posVal = 4;
             }
             if (t.y > 0)
             {
                 PosValueY = 4;
             }
             else if (t.y < 0)
             {
                 PosValueY = 0;
             }
             transform.position = new Vector3(posVal, PosValueY,transform.position.z);
         }*/

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jump(); 
        }
        if (transform.position.y < -5)
        {
            Die();
        }
       
    }
      public  void Die()
      {
        alive = false;
        Destroy(gameObject); SceneManager.LoadScene("Menu 3D");
    }

    void jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, GroundMask);

        if (isGrounded)
           { rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); }
    }
}
