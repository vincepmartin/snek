using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekBoard : MonoBehaviour
{
    public Vector3 scale = new Vector3(20f, .5f, 20f);
    public Vector3 position = Vector3.zero;

    private GameObject floor;

    // Allow me to set items via code.
    public void InitWithProps(Vector3? scale = null, Vector3? position = null)
    {
        this.scale = (Vector3)((scale == null) ? this.scale: scale);
        this.position = (Vector3)((position == null) ? this.position: position);
    }

    // Start is called before the first frame update
    void Start()
    {
        tag = "snekboard";
        // Verify: Is this scale even needed?
        transform.localScale = scale;
        transform.position = position;
        CreateFloor();
        CreateWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateFloor()
    {
        Debug.Log("Creating a floor");
        floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "floor";
        floor.transform.localScale = scale;
        floor.transform.position = position;
        var r = floor.GetComponent<MeshRenderer>();
        r.material.SetColor("_Color", Color.blue);
        // TODO: Add colliders etc. 
        Instantiate(floor);
    }

    void CreateWalls()
    {
        Debug.Log("Creating walls");
    }
}
