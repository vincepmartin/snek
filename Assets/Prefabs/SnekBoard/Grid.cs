using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    // Scale of the grid.  Going to try to use this to create the board with the same size.
    private Vector3 gridScale;

    public Grid(int width, int height, float cellSize, Transform transformParent)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        gridScale = new Vector3(width * cellSize, 0, height * cellSize);

        // Cycle through every item in our grid.
        int count = 0;
        for (int z = 0; z < gridArray.GetLength(1); z++)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                gridArray[x, z] = count;
                count += 1;
                UtilsClass.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z), 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(((x * cellSize) + cellSize / 2), 0, (y * cellSize) + cellSize / 2); 
    }

    // Get grid position so that you can draw things over grid.
    public Vector3 GetScale()
    {
        return gridScale;
    }
}
