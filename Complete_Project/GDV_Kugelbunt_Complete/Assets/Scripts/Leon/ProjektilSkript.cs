using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilSkript : MonoBehaviour {

    public float selbstzerstörung = 5;
    public float speed = 10;

    public float maxGroesse = 4;
    public float wachsen = 0.5f;
    public GameObject projektil; //muss in Remedy  als Ziel gesetzt werden, sollte im Prefab schon passiert sein


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

        if (projektil.transform.localScale.x <= maxGroesse)
        {
            transform.localScale += new Vector3(wachsen * Time.deltaTime, wachsen * Time.deltaTime, wachsen * Time.deltaTime); //kugel wächst mit der Zeit
        }
    }
}
