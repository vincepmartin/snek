using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekBoard : MonoBehaviour
{
    public Vector3 scale = new Vector3(20f, .5f, 20f);
    public Vector3 position = Vector3.zero;


    public float wallHeight = 1f;
    public float wallThickness = .5f;
    public float floorThickness = .25f;
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
        floor.transform.localScale = new Vector3(scale.x, floorThickness, scale.z);
        floor.transform.position = position;
        floor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        floor.GetComponent<BoxCollider>().isTrigger = true;
    }

    void CreateWalls()
    {
        // TODO: I feel like this can be done w/ some more simple Vector3 math.
        // Create walls, starting at top (0) and going counter clockwise.
        Debug.Log("Creating walls");
        wall0 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall0.name = "wall0";
        wall0.transform.position = new Vector3(0, (wallHeight / 2) - (this.scale.y/2), scale.z / 2 + (wallThickness / 2));
        wall0.transform.localScale = new Vector3(this.scale.x, wallHeight, wallThickness);
        wall0.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        wall0.GetComponent<BoxCollider>().isTrigger = true;

        wall1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall1.name = "wall1";
        wall1.transform.position = new Vector3(scale.x / 2 + (wallThickness / 2), (wallHeight / 2) - (this.scale.y/2), 0);
        wall1.transform.localScale = new Vector3(wallThickness, wallHeight, this.scale.z + (wallThickness * 2));
        wall1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        wall1.GetComponent<BoxCollider>().isTrigger = true;
        
        wall2 = Instantiate(wall0);
        wall2.name = "wall2";
        wall2.transform.position = new Vector3(wall2.transform.position.x, wall2.transform.position.y, wall2.transform.position.z * -1);

        wall3 = Instantiate(wall1);
        wall3.name = "wall3";
        wall3.transform.position = new Vector3(wall3.transform.position.x * -1, wall3.transform.position.y, wall3.transform.position.z);
    }

    void CreateSnake()
    {

    }

    void CreateApple()
    {
        // Find random location within grid to place an apple.
    }
}
