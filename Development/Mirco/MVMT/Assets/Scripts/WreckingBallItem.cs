using System;
using System.Collections;
using UnityEngine;

public class WreckingBallItem : MonoBehaviour {

    Collider boxCollider;
    //public Transform Wall;
    private float delayTillReset = 5;
    private int wallLayer, playerLayer;
    public BoxCollider Wall;
    //public GameObject Wall;

    private void Start()
    {
        wallLayer = LayerMask.NameToLayer("Walls");
        boxCollider = GetComponent<Collider>();
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerLayer == default(int))
            {
                playerLayer = other.gameObject.layer;
            }
            AudioManager.Instance.Play("pickUp");
            StartCoroutine(WreckingBall());
        }
    }

    IEnumerator WreckingBall()
    {
        Physics.IgnoreLayerCollision(playerLayer, wallLayer);
        boxCollider.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(delayTillReset);
        Physics.IgnoreLayerCollision(playerLayer, wallLayer, false);
        boxCollider.enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
