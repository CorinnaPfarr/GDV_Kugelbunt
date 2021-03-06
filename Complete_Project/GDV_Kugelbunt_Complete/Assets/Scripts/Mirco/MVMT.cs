﻿//using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class MVMT : MonoBehaviour {

    #region Mirco
    public AudioManager audioManager;
    public Rigidbody rb; // reference to the Rigidbody called "rb"
    //public float forwardForce = 700f; //Speed of the ForwardForce
    //public float sidewaysForce = 500f; //Speed of the SidewaysForce
    public Vector3 movement;
    public float jumpFactor = 0.0f;
    public float speed = 10;
    public float heightToRespawn = -35;
    public float waitTimeBetweenBlinks = 0.25f;
    public int maxBlinkCount = 4;
    HealthSystem healthSystem = new HealthSystem(9);
    
    private MeshRenderer meshRenderer;
    private Vector3 startPosition;
    private Vector3 newPosition;

    //materialArray für die "Lebensanzeige" de Balls
    public Material[] material;
    Renderer rend;


    public bool wreckingBall = false;
    

    //Anfang Leons Codeeinschub
    public float warteZeit;
    public bool blocked=false;
    public float tempSpeed;
    //ende Leons Codeeinschub

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioManager = AudioManager.Instance;
        startPosition = gameObject.transform.position;
        healthSystem.GetHealth();
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || gameObject.transform.position.y <= heightToRespawn)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        gameObject.transform.position = startPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(Vector3.zero);

        Reanimate();
    }

    private void Reanimate()
    {
        StartCoroutine(Blink(maxBlinkCount));
        healthSystem.Heal(healthSystem.healthMax);
        rend.sharedMaterial = material[0];
    }

    private IEnumerator Blink(int maxBlinkCount)
    {
        int blinkCount = 0;

        while (blinkCount < maxBlinkCount)
        {
            yield return new WaitForSeconds(waitTimeBetweenBlinks);
            meshRenderer.enabled = false;
            yield return new WaitForSeconds(waitTimeBetweenBlinks);
            meshRenderer.enabled = true;
            blinkCount++;
            yield return null;
        }
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        Move();

        //anfang Leons Codeeinschub
        if (blocked == true)
        {
            warteZeit -= Time.deltaTime;
            if (warteZeit <= 0f)
            {
                freiheit();
            }
        }
        //Ende Leons Codeeinschub
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, jumpFactor, moveVertical);
        
        rb.AddForce(movement * speed);

        #region old Movement
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
        #endregion


    }
    //anfang Leons Codeeinschub
    public void festhalten()   //wenn der Gegner den Spieler einholt wird diese aktiviert->in Update geht es weiter *Leon
    {
        AudioManager.Instance.Play("festhalten");
        tempSpeed = speed;
        speed = 0;
        blocked = true;
        warteZeit = 2.0f;
    }

    void freiheit()
    {
        blocked = false;
        speed = tempSpeed;
    }
    //Ende Leons Codeeinschub

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("WreckingBall"))
    //    {
    //        other.gameObject.SetActive(false);
    //        wreckingBall = true;

    //       // boxCollider.isTrigger = true;
    //    }

    //    if (other.gameObject.CompareTag("Wall") && wreckingBall == true)
    //    {
    //        other.gameObject.SetActive(false);
    //    }
    //}

    //Lässt den Spielball kaputter aussehen, wenn er öfter kollidiert
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<WallScript>() || col.gameObject.GetComponent<Block>() || col.gameObject.CompareTag("KanonenKugel"))
        {
            AudioManager.Instance.Play("impact");
            healthSystem.Damage(1);
            if(healthSystem.GetHealth() <= 0)
            {
                Respawn();
            }
            else if (healthSystem.GetHealth() < 3)
            {
                rend.sharedMaterial = material[2];
            }
            else if (healthSystem.GetHealth() < 6)
            {
                rend.sharedMaterial = material[1];
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            newPosition = gameObject.transform.position;
            startPosition = newPosition;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.gameObject.CompareTag("Ziel"))
        {
            AudioManager.Instance.Play("Ziel");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }





    #endregion



}






