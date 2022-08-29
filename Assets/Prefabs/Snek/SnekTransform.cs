using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekTransform : MonoBehaviour
{

    // private Dictionary<string, Collider> bodiesInTrigger;
    private Queue<Collider> bodiesQueue;
    private List<string> bodiesAlreadyActedOn;
    public float snapDistance = .0015f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "bodyTransform";
        bodiesAlreadyActedOn = new List<string>();
        bodiesQueue = new Queue<Collider>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (bodiesQueue.Count > 0 )
        {
            Collider bodyCollider = bodiesQueue.Peek();
            if (Vector3.Distance(bodyCollider.gameObject.transform.position, transform.position) < snapDistance) {
                bodyCollider.gameObject.transform.position = transform.position;
                bodyCollider.gameObject.transform.rotation = transform.rotation;
                bodiesAlreadyActedOn.Add(bodyCollider.gameObject.name);
                bodiesQueue.Dequeue();
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "body")
        {
            if (!bodiesAlreadyActedOn.Contains(other.gameObject.name))
            {
                Debug.Log("Adding: " + other.gameObject.name);
                bodiesQueue.Enqueue(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "body")
        {
            // Debug.Log("Removing: " + other.gameObject.name);
            // bodiesInTrigger.Remove(other.gameObject.name);
        }
    }
}
