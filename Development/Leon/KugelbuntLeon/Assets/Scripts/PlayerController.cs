using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public float warteZeit;
    public bool blocked;

    private Rigidbody rb;

    void Start()
    {
 
        speed = 10;
        rb = GetComponent<Rigidbody>();

        blocked = false;
        
    }

    void update()
    {
  
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


        if (blocked == true)
        {
            warteZeit -= Time.deltaTime;
            if (warteZeit <= 0f)
            {
                freiheit();
            }
        }
    }

    public void festhalten()   //wenn der Gegner den Spieler einholt wird diese aktiviert->in Update geht es weiter *Leon
    {
        speed = 0;
        blocked = true;
        warteZeit = 2.0f;
    }

    void freiheit()
    {
        blocked = false;
        speed = 10;
    }
}