using System.Collections;
using UnityEngine;

public class Colission : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            //Destroy(col.gameObject);
           // forwardForce = 700f;
        }
    }
}
