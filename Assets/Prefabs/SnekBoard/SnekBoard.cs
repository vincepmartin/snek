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
        tag = "snekboard";
        boardGrid = new Grid(xSize, ySize);

        PopulateBoardGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateBoardGrid()
    {
        // Y
        for (int i = 0; i < ySize; i ++)
        {
            // X 
            for (int j = 0; j < xSize; j++)
            {
                boardGrid.Add(i, j, Instantiate(floorPrefab, transform, false));
                boardGrid.Get(i, j).transform.localPosition = GetPosition(j, i);
                boardGrid.Get(i, j).transform.localScale = new Vector3(cellWidth, boardGrid.Get(i,j).transform.localScale.y, cellWidth);
                boardGrid.Get(i, j).name = "Floor: " + j + ", " + i;
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
