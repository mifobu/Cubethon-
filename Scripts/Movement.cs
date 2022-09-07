using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sideForce = 1500f;


    // Update is called once per frame
    void FixedUpdate() {
        if (true) {
        rb.velocity = new Vector3(0, 0, 7);
        }
        if (Input.GetKey("d")){
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a")){
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.x < -4f ||  rb.position.x  > 4f){
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
