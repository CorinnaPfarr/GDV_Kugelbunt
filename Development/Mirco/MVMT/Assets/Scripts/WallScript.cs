using UnityEngine;

public class WallScript : MonoBehaviour
{

    Collider boxCollider;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
    

    }
}
