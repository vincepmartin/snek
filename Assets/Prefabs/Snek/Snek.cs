using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public float speed = 1f;
    public int bodySize = 1;
    public int maxSize = 20;
    private int bodyTransforms = 0;

    public GameObject bodyObject;
    public GameObject transformObject;

    // Bodies
    private GameObject[] bodies;

    // Store array of vector3s
    private Vector3[] locationHistory;
    private int latestLocationHistory = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Init our location history and add our first position.
        locationHistory = new Vector3[10000];
        locationHistory[0] = transform.position;

        // Create any body objects that are required.
        bodies = new GameObject[maxSize];
        for (int i = 0; i < bodySize; i++ )
        {
            Debug.Log("Adding a body...");
            bodyObject = Instantiate(bodyObject, transform.position - new Vector3(0, 0, (i+1)) , transform.rotation);
            bodyObject.name = $"body{i}";
            bodies[i] = bodyObject;
        }

        gameObject.tag = "snake";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) {
            transform.RotateAround(transform.position, transform.up, -90f);
            Instantiate(transformObject, transform.position, transform.rotation);
            // RotateBodies(-90f);
        }

        if (Input.GetKeyDown("right")) {
            transform.RotateAround(transform.position, transform.up, 90f);
            Instantiate(transformObject, transform.position, transform.rotation);
            // RotateBodies(90f);
        }

        // Instantiate a body object.
        if (Input.GetKeyDown("n")) {
            Debug.Log("*******");
            Debug.Log("Add a new body...");
            Debug.Log("*******");
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Move all of the bodies Forward
        MoveBodies(); 

        if (Vector3.Distance(locationHistory[latestLocationHistory], transform.position) >= 1) {
            // Debug.Log("Adding a new Location to history");
            latestLocationHistory += 1;
            locationHistory[latestLocationHistory] = transform.position;
        }
    }

    // Translate all snake bodies.
    void MoveBodies()
    {
        for (int i = 0; i < bodySize; i ++) {
            bodies[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
