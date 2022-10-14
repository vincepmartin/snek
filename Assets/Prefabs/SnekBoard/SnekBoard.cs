using UnityEngine;

public class SnekBoard : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public int xSize;
    public int ySize;
    public float cellWidth;
    private Grid boardGrid;
    
    // Start is called before the first frame update
    void Start()
    {
        name = "SnekBoard";
        // The + 2 allows for the walls to be rendered.
        boardGrid = new Grid(xSize + 2, ySize + 2);

        PopulateBoardGrid();
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
                boardGrid.Get(i, j).name = isWall ? "Wall: " : "Floor: " + j + ", " + i;
            }
        }
    }
   
    Vector3 GetPosition(int x, int y)
    {
        return new Vector3(x * cellWidth, 0, y * cellWidth); 
    }    

    void CreateSnake()
    {
    
    }

    void CreateApple()
    {
   
    }
}
