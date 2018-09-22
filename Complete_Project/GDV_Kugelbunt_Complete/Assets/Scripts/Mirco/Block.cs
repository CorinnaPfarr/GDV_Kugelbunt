using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!rbody.isKinematic)
            rbody.isKinematic = true;
    }
}
