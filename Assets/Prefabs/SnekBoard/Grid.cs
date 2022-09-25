using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private Transform transformParent;

    public Grid(int width, int height, float cellSize, Transform transformParent)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.transformParent = transformParent;

        gridArray = new int[width, height];

        // Cycle through every item in our grid.
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log("Init (x, y): " + "(" + x + ", " + y + ")");
                UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y), 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, 0, y) * cellSize; 
    }
}
