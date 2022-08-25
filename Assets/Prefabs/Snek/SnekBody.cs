using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekBody : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Body hit a triger of: ");
        Debug.Log(collider);
        transform.rotation = collider.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
