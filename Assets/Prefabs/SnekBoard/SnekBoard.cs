using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekBoard : MonoBehaviour
{
    // TODO: Remove and convert me to gridWidth, gridHeight, and cellSize (f). 
    public Vector3 position = Vector3.zero;
    private Vector3 scale;
    public int gridWidth;
    public int gridHeight;
    public float cellSize = 5f;

    public float wallHeight = 1f;
    public float wallThickness = .5f;
    public float floorThickness = .25f;
    private Grid grid;
    private GameObject floor;
    private GameObject wall0;
    private GameObject wall1;
    private GameObject wall2;
    private GameObject wall3;

    // Allow me to set items via code.
    public void InitWithProps(Vector3? position = null, int gridWidth = 2, int gridHeight = 2)
    {
        // TODO: Set scale and position baesd on values from grid... 
        // this.scale = (Vector3)((scale == null) ? this.scale: scale);
        this.gridWidth = gridWidth;
        this.gridHeight = gridHeight;
        this.position = (Vector3)((position == null) ? this.position: position);
    }

    // Start is called before the first frame update
    void Start()
    {
        tag = "snekboard";
        transform.position = position;
            
        // Create Grid and then use it to set scale of our board.
        CreateGrid();

        // Get position based on the grid.
        position.x += grid.GetScale().x / 2;
        position.z += grid.GetScale().z / 2;
        Debug.Log("Console Grid Scale: ");
        Debug.Log(grid.GetScale());

        CreateFloor();
        CreateWalls();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void CreateGrid()
    {
        grid = new Grid(gridWidth, gridHeight, cellSize, null);
        scale = grid.GetScale();
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
        floor.transform.SetParent(transform, false);
    }

    void CreateWalls()
    {
        // TODO: I feel like this can be done w/ some more simple Vector3 math.
        // Create walls, starting at top (0) and going clockwise.
        Debug.Log("Creating walls");
        wall0 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall0.name = "wall0";
        wall0.transform.SetParent(transform);
        wall0.transform.position = new Vector3(position.x, (wallHeight - floorThickness) / 2 , scale.z);
        wall0.transform.localScale = new Vector3(scale.x, wallHeight, wallThickness);
        wall0.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        wall0.GetComponent<BoxCollider>().isTrigger = true;

        wall1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall1.name = "wall1";
        wall1.transform.SetParent(transform);
        wall1.transform.position = new Vector3(floor.transform.localScale.x + (wallThickness/2), (wallHeight - floorThickness) / 2, floor.transform.localScale.z/2);
        wall1.transform.localScale = new Vector3(wallThickness, wallHeight, grid.GetScale().z + wallThickness);
        wall1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
        wall1.GetComponent<BoxCollider>().isTrigger = true;
        
        wall2 = Instantiate(wall0);
        wall2.name = "wall2";
        wall2.transform.SetParent(transform);
        wall2.transform.position = new Vector3(wall2.transform.position.x, wall2.transform.position.y, wall2.transform.position.z - scale.z);

        wall3 = Instantiate(wall1);
        wall3.name = "wall3";
        wall3.transform.SetParent(transform);
        wall3.transform.position = new Vector3(floor.transform.position.x - (floor.transform.localScale.x / 2), wall3.transform.position.y, wall3.transform.position.z);
    }

    void CreateSnake()
    {

    }

    void CreateApple()
    {
        // Find random location within grid to place an apple.
    }
}
