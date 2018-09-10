
using UnityEngine;

public class MVMT : MonoBehaviour {

    public Rigidbody rb; // reference to the Rigidbody called "rb"
    public float forwardForce = 700f; //Speed of the ForwardForce
    public float sidewaysForce = 500f; //Speed of the SidewaysForce

    // Update is called once per frame 
    void FixedUpdate () {

        //add forward and backward Force
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

       
        //add SidewayForce
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
	}
}
