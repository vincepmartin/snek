using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekBody : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() {
        gameObject.tag = "body";    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
    
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
