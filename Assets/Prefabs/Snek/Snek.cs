using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public float speed = 1f;
    public int bodySize = 1;
    public int maxSize = 20;
    public int gap = 50;
    public int bodyGrowthRate = 4;

    // Bodies
    public GameObject bodyPrefab;
    public GameObject boardPrefab;
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

        // Instantiate a new body object.
        if (Input.GetKeyDown("n")) {
            AddBody(1);
        }

        // TODO: Remove me, create a new board for testing.
        if (Input.GetKeyDown("b")) {
            Instantiate(boardPrefab).GetComponent<SnekBoard>().InitWithProps(new Vector3(10f, .3f, 10f));
        }

        // Move the head forward.
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
        int index = 1;
        foreach (var body in bodies)
        {
            Vector3 point = locationHistory[Mathf.Min(index * gap, locationHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position = point;
            // body.transform.LookAt(moveDirection);
            index++;
        }
    }

    // Handle our Collisions.
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Hit!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Snek Trigger Entered: " + other.gameObject.name);

        if (other.gameObject.tag.Equals("apple"))
        {
            AddBody(bodyGrowthRate);
            Destroy(other.gameObject);
        }
    }
}
