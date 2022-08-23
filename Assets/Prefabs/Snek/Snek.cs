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
        if (Input.GetKeyDown("left")) 
        {
            transform.RotateAround(transform.position, transform.up, -90f);
            
        }
        if (Input.GetKeyDown("right")) 
        {
            transform.RotateAround(transform.position, transform.up, 90f);
        }

        /*  TODO: Fix this...
        if (Input.GetAxis("Horizontal") > 0) {
            horizontal = 1;
            vertical = 0;
            transform.RotateAround(transform.position, transform.up, 90f);
        }

        if (Input.GetAxis("Horizontal") < 0) {
            Debug.Log("GO LEFT");
            horizontal = -1;
            vertical = 0;
            // transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);
            transform.RotateAround(transform.position, transform.up, -90f);
        }
        */

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
