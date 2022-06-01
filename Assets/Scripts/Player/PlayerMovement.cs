using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 20f;
    public float speed = 1f;
    private float range = 7f;
  
    void Update()
    {
        transform.Translate(Vector3.forward * forwardForce * Time.deltaTime);
        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }

        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
       // transform.Translate(Vector3.forward * forwardForce * Time.deltaTime);
        
       // rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //if (Input.GetKey("d"))
        //{
        //    rb.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (Input.GetKey("a"))
        //{
        //    rb.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (rb.position.y < -1f) 
        //{
        //    FindObjectOfType<GameManager>().EndGame();
        // }
    }
}
