using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil2Skript : MonoBehaviour
{

    public float selbstzerstörung = 5;
    public float speed = 5;

    public float maxGroesse = 4;
    public float wachsen = 0.5f;
    public GameObject projektil2; //muss in Remedy  als Ziel gesetzt werden, sollte im Prefab schon passiert sein
    private Rigidbody rb;


    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        selbstzerstörung -= Time.deltaTime;

 


        if (selbstzerstörung <= 0f)
        {
            Destroy(gameObject);
        }

        if (projektil2.transform.localScale.x <= maxGroesse)
        {
            transform.localScale += new Vector3(wachsen * Time.deltaTime, wachsen * Time.deltaTime, wachsen * Time.deltaTime); //kugel wächst mit der Zeit
        }
    }

    void FixedUpdate()
    {
        Vector3 v3Force = speed * transform.forward;
        rb.AddForce(v3Force);
    }
}