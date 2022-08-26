using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekTransform : MonoBehaviour
{

    private Dictionary<string, Collider> bodiesInTrigger;
    public float snapDistance = .0015f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "bodyTransform";
        bodiesInTrigger = new Dictionary<string, Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any of our colliders are perfect matches... 
        foreach (KeyValuePair<string, Collider> kvp in bodiesInTrigger)
        {
            Collider bodyCollider = kvp.Value;
            if (Vector3.Distance(bodyCollider.gameObject.transform.position, transform.position) < snapDistance)
            {
                // Debug.Log($"{kvp.Key} distance: {Vector3.Distance(bodyCollider.gameObject.transform.position, transform.position)}");
                bodyCollider.gameObject.transform.position = transform.position;
                bodyCollider.gameObject.transform.rotation = transform.rotation;
                bodiesInTrigger.Remove(kvp.Key);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "body")
        {
            // Debug.Log("Adding: " + other.gameObject.name);
            bodiesInTrigger[other.gameObject.name] = other;
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
