using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public float speed = 1f;
    public int bodySize = 1;
    public int maxSize = 20;
    public int gap = 50;

    // Bodies
    public GameObject bodyPrefab;
    private List<GameObject> bodies;

    // Store array of vector3s
    private List<Vector3> locationHistory;
    
    // Start is called before the first frame update
    void Start()
    {
        locationHistory = new List<Vector3>();

        // Create any body objects that are required.
        bodies = new List<GameObject>();
        for (int i = 0; i < bodySize; i++ )
        {
            AddBody(i);
        }

        gameObject.tag = "snake";
    }

    private void AddBody(int i)
    {
        bodies.Add(Instantiate(bodyPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) {
            transform.RotateAround(transform.position, transform.up, -90f);
        }

        if (Input.GetKeyDown("right")) {
            transform.RotateAround(transform.position, transform.up, 90f);
        }

        // Instantiate a body object.
        if (Input.GetKeyDown("n")) {
            AddBody(1);
        }

        // Move the head.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Add to our position log.
        locationHistory.Insert(0, transform.position);

        // Move body parts.
        MoveBodies(gap); 
    }

    // Translate all snake bodies.
    // Help from https://youtu.be/iuz7aUHYC_E
    void MoveBodies(int gap)
    {
        int index = 0;
        foreach (var body in bodies)
        {
            Vector3 point = locationHistory[Mathf.Min(index * gap, locationHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position = point;
            // body.transform.LookAt(moveDirection);
            index++;
        }
    }
}
