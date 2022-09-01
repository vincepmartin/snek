using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekBoard : MonoBehaviour
{
    public Vector3 scale = new Vector3(20f, .5f, 20f);
    public Vector3 position = Vector3.zero;


    private float wallHeight = 1f;
    private float wallThickness = .5f;
    private GameObject floor;
    private GameObject wall0;
    private GameObject wall1;
    private GameObject wall2;
    private GameObject wall3;

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
        floor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        floor.GetComponent<BoxCollider>().isTrigger = true;
    }

    void CreateWalls()
    {
        Debug.Log("Creating walls");
        wall0 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall0.name = "wall0";
        wall0.transform.position = new Vector3(0, (wallHeight / 2) - (this.scale.y/2), scale.z / 2 + (wallThickness / 2));
        wall0.transform.localScale = new Vector3(this.scale.x, wallHeight, wallThickness);
        wall0.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        wall0.GetComponent<BoxCollider>().isTrigger = true;

        wall2 = Instantiate(wall0);
        wall2.name = "wall2";
        wall2.transform.position = new Vector3(wall2.transform.position.x, wall2.transform.position.y, wall2.transform.position.z * -1);
    }
}
