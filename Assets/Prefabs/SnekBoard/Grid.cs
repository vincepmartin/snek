using UnityEngine;
using CodeMonkey.Utils;
using UnityEditor.UIElements;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;

public class Grid {
    private int x;
    private int y;
    private GameObject[,] gridArray;

    // Scale of the grid.  Going to try to use this to create the board with the same size.
    private Vector3 gridScale;

    // Constructor with gridArray items.
    public Grid(GameObject[,] items)
    {
        // Set our x and y.
        y = items.Length;
        x = items.GetLength(1);
        gridArray = items;
    }

    // Constructor with dimensions with no gridArray data.
    public Grid(int x, int y)
    {
        this.x = x;
        this.y = y;
        gridArray = new GameObject[x, y];
    }
    
    public void Add(int x, int y, GameObject item)
    {
        gridArray[x, y] = item; 
    }

    public GameObject Get(int x, int y) {
        return gridArray[x, y]; 
    }
    
    public GameObject[] GetAllItems()
    {
        // Step 1: get total size of 2D array, and allocate 1D array.
        int size = gridArray.Length;
        GameObject[] result = new GameObject[size];

        // Step 2: copy 2D array elements into a 1D array.
        int write = 0;
        for (int i = 0; i <= gridArray.GetUpperBound(0); i++)
        {
            for (int z = 0; z <= gridArray.GetUpperBound(1); z++)
            {
                result[write++] = gridArray[i, z];
            }
        }
        // Step 3: return the new array.
        return result;   
    }
}
