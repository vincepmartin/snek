using UnityEngine;

public class SnekBoard : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public GameObject snakePrefab;
    public int xSize;
    public int ySize;
    public float cellWidth;

    private Grid<GameObject> boardGrid;
    private Grid<Vector3> actionGrid;

    private const bool DEBUG = false;

    // Start is called before the first frame update
    void Start()
    {
        name = "SnekBoard";
        // The + 2 allows for the walls to be rendered.
        boardGrid = new Grid<GameObject>(xSize + 2, ySize + 2);
        actionGrid = new Grid<Vector3>(xSize, ySize);

        PopulateBoardGrid();
        CreateActionGrid();
        CreateSnake(3, 3);
        EncalsulateBoardWithCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateBoardGrid()
    {
        // Y
        for (int i = 0; i < ySize + 2; i ++)
        {
            // X 
            for (int j = 0; j < xSize + 2; j++)
            {
                bool isWall = (i == 0 || i == ySize + 1 || j == 0 || j == xSize + 1);
                boardGrid.Add(i, j, Instantiate(isWall ? wallPrefab: floorPrefab, transform, false));
                boardGrid.Get(i, j).transform.localPosition = GetPosition(j, i);
                boardGrid.Get(i, j).transform.localScale = new Vector3(cellWidth, boardGrid.Get(i, j).transform.localScale.y, cellWidth);
                boardGrid.Get(i, j).transform.localPosition = new Vector3(boardGrid.Get(i,j).transform.localPosition.x, boardGrid.Get(i,j).transform.localPosition.y + boardGrid.Get(i,j).transform.localScale.y / 2, boardGrid.Get(i, j).transform.localPosition.z);
                boardGrid.Get(i, j).name = (isWall ? "Wall: " : "Floor: ") + j + ", " + i;
            }
        }
    }

    // Create the action grid, which is essentially just coordinate locations that sit on top of the "FLOOR" of our board...
    void CreateActionGrid()
    {
        // Y
        for (int i = 0; i < ySize; i++)
        {
            // X
            for (int j = 0; j < xSize; j++)
            {
                GameObject t = boardGrid.Get(i + 1, j + 1);
                Debug.Log("Getting: " + t.name + " at " + t.transform.position);
                actionGrid.Add(i, j, new Vector3(t.transform.localPosition.x, t.transform.localPosition.y + cellWidth, t.transform.localPosition.z));

                // Put some items at our grid to make sure it is placed properly. 
                if (DEBUG)
                {
                    GameObject temp = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), transform, false);
                    temp.transform.localScale = new Vector3(.1f, .1f, .1f);
                    temp.transform.localPosition = actionGrid.Get(i, j);
                } 
            }
        }
    }   

    private Vector3 GetPosition(int x, int y)
    {
        return new Vector3(x * cellWidth, 0, y * cellWidth); 
    }    

    private Vector3 GetActionPosition(int x, int y)
    {
        return actionGrid.Get(x, y);
    }

    // TODO: Fix body so that body parts are sibling components to the head.
    void CreateSnake(int snakeX, int snakeY)
    {
        Debug.Log("Create Snake at " + snakeX + ", " + snakeY);
        GameObject snake = Instantiate(snakePrefab, transform, false);
        snake.transform.localPosition = actionGrid.Get(3, 3);
    }
    // TODO: Check all child objects and add them to Bounds that can be used to create a 3d collider box.
    private void EncalsulateBoardWithCollider()
    {

    }

    // TODO: Implement creation of apple.
    void CreateApple()
    {
   
    }
}
