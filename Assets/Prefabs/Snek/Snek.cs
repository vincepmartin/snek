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
        Debug.Log("Vert:");
        Debug.Log(Input.GetAxis("Vertical"));
        Debug.Log("Hori:");
        Debug.Log(Input.GetAxis("Horizontal"));

        // Get input
        if (Input.GetAxis("Vertical") > 0) {
            // vertical = Input.GetAxis("Vertical");
            Debug.Log("GO UP");
            vertical = 1;
            horizontal = 0;
        } else {
            Debug.Log("GO DOWN");
            vertical = -1;
            horizontal = 0;
        }

        if (Input.GetAxis("Horizontal") > 0) {
            Debug.Log("GO RIGHT");
            // horizontal = Input.GetAxis("Horizontal");
            horizontal = 1;
            vertical = 0;
        } else {
            Debug.Log("GO LEFT");
            horizontal = -1;
            vertical = 0;
        }

        // Some debug stuff.
        // Debug.Log("**** Inputs ****");
        // Debug.Log("Input Vertical: " + vertical);
        // Debug.Log("Vertical: " + vertical);
        // Debug.Log("Input Horizontal: " + horizontal);
        // Debug.Log("Horizontal: " + horizontal);
        // Debug.Log("****************");

        // Update position
        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime); 
    }
}
