using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public float speed = 1f;

    private float horizontal = 0;
    private float vertical = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        if (Input.GetAxis("Vertical") > 0) {
            vertical = 1;
            horizontal = 0;
        }
        
        if (Input.GetAxis("Vertical") < 0){
            vertical = -1;
            horizontal = 0;
        }

        if (Input.GetAxis("Horizontal") > 0) {
            horizontal = 1;
            vertical = 0;
        } 
        
        if (Input.GetAxis("Horizontal") < 0) {
            Debug.Log("GO LEFT");
            horizontal = -1;
            vertical = 0;
        }

        // Update position
        // TODO: Consider putting this into a queue or something so the rest of the body can follow this...
        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime); 
    }
}
