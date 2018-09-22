using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour {
    public ParticleSystem particles;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MVMT>())
        {
            if (other.gameObject.GetComponent<MVMT>().wreckingBall)
            {
                StartCoroutine(DestroyWall());
                
            }
        }
    }

    private IEnumerator DestroyWall()
    {
        gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
        particles.Play();
        while(particles.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject.transform.parent.gameObject);
    }
}
