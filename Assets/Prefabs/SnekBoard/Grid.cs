using UnityEngine;
using CodeMonkey.Utils;
using UnityEditor.UIElements;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;

public class Grid<T> {
    private int x;
    private int y;
    private T[,] gridArray;

    // Scale of the grid.  Going to try to use this to create the board with the same size.
    private Vector3 gridScale;

    // Constructor with gridArray items.
    public Grid(T[,] items)
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
        gridArray = new T[x, y];
    }
    
    public void Add(int x, int y, T item)
    {
        gridArray[x, y] = item; 
    }

    public T Get(int x, int y) {
        return gridArray[x, y]; 
    }
    
    public T[] GetAllItems()
    {
        // Step 1: get total size of 2D array, and allocate 1D array.
        int size = gridArray.Length;
        T[] result = new T[size];

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
