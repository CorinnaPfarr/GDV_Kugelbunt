using UnityEngine.SceneManagement;
using UnityEngine;

public class MVMT : MonoBehaviour {

    public Rigidbody rb; // reference to the Rigidbody called "rb"
    //public float forwardForce = 700f; //Speed of the ForwardForce
    //public float sidewaysForce = 500f; //Speed of the SidewaysForce
    public Vector3 movement;
    public float jumpFactor = 0.0f;
    public float speed = 15;

    // Update is called once per frame 
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, jumpFactor, moveVertical);
        
        rb.AddForce(movement * speed);

        //add forward and backward Force
        //if (Input.GetKey("w"))
        //{
        //    speedForward = forwardForce * Time.deltaTime;
        //    rb.AddForce(0, 0, speedForward);
        //}

        //if (Input.GetKey("s"))
        //{
        //    rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        //}


        ////add SidewayForce
        //if (Input.GetKey("d"))
        //{
        //    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,);
        //}

        //if (Input.GetKey("a"))
        //{
        //    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        //}
    }

}
    



        

