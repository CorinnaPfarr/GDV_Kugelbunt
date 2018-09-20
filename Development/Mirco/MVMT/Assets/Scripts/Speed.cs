using System.Collections;
using UnityEngine;

public class Speed : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private MVMT mvmtScript;
    [SerializeField] private float newSpeed = 30;
    [SerializeField] private float delayTillReset = 5;

    private float oldSpeed;

    private void Start()
    {
        mvmtScript = player.GetComponent<MVMT>();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        GameObject collingObject = collision.gameObject;
        if (collingObject.gameObject == player)
        {
            if (mvmtScript.speed != newSpeed)
            {
                oldSpeed = mvmtScript.speed;
                StartCoroutine(ResetSpeed());
                Debug.Log(mvmtScript.speed);
            }
        }
    }

    IEnumerator ResetSpeed()
    {
        mvmtScript.speed = newSpeed;
        yield return new WaitForSeconds(delayTillReset);
        mvmtScript.speed = oldSpeed;
    }
}