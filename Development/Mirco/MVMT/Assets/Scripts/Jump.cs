using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    [SerializeField] private float _jumpFactor = 30;
    public GameObject player;

    protected void OnCollisionEnter(Collision collision)
    {
        GameObject collingObject = collision.gameObject;
        if (collingObject.gameObject == player)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpFactor, ForceMode.Impulse);
        }
    }
}
