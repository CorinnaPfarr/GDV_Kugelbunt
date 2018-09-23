
using UnityEngine;

public class CameraMVMT : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        transform.Rotate(10, 0, 0);

    }


    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

    }

    
    
}


 