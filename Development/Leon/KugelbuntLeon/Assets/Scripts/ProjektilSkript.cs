using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilSkript : MonoBehaviour {

    public float selbstzerstörung = 5;
    public float speed = 10;


	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
        selbstzerstörung -= Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        if (selbstzerstörung <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
