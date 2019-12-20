using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    public int rows = 10;
    public int columns = 5;
    public int scale = 1;
    public int floorHeight = 15;

    public GameObject gridPrefab;
    public GameObject unitPrefab1, unitPrefab2, unitPrefab3;
    public GameObject[,] gridArray;
    public bool[,] gridArrayInUse;
    public Vector3 leftBottomLocation = new Vector3(0, 0, 0);


    void Awake()
    {
        if (gridPrefab)
            GenerateGrid();
        else
            Debug.Log("missing gridPrefab object reference; assign.");

        if (unitPrefab1 || unitPrefab2 || unitPrefab3)
            GenerateChars();
        else
            Debug.Log("missing unit1 character object reference; assign.");
    }

    void Update()
    {
        CheckValidMovement((int)unitPrefab1.transform.position.x, (int)unitPrefab1.transform.position.z);
    }

    void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject gridObj = Instantiate(gridPrefab, new Vector3(leftBottomLocation.x + scale * i, leftBottomLocation.y, leftBottomLocation.z + scale * j), Quaternion.identity);
            }
        }
    }

    void GenerateChars()
    {
        // grid begins with 0,0 being the bottom left corner
        // ends with 9,4
        // moving one block's worth in any direction is 20 game units (center of block)

        // first unit spawns at 0,15,0
        GameObject firstUnit = Instantiate(unitPrefab1, new Vector3(leftBottomLocation.x + scale * 0, floorHeight, leftBottomLocation.z + scale * 0), Quaternion.identity);
        
        // second unit spawns at 40,15,0
        GameObject secondUnit = Instantiate(unitPrefab2, new Vector3(leftBottomLocation.x + scale * 2, 15, leftBottomLocation.z + scale * 0), Quaternion.identity);

        // third unit spawns at 80,15,0
        GameObject thirdUnit = Instantiate(unitPrefab3, new Vector3(leftBottomLocation.x + scale * 4, 15, leftBottomLocation.z + scale * 0), Quaternion.identity);
        
    }

    bool CheckValidMovement(int x, int y)
    {
        var direction = Input.inputString;

        switch (direction)
        {
            // Up
            case "w":
                Debug.Log("W");
                if ((y + 1 < rows && gridArray[x, y + 1]) || gridArrayInUse[x, y + 1] == true)
                    return true;
                else
                    return false;
            // Down    
            case "s":
                Debug.Log("S");
                if ((y - 1 < rows && gridArray[x, y - 1]) || gridArrayInUse[x, y - 1] == true)
                    return true;
                else
                    return false;
            // Left
            case "a":
                Debug.Log("A");
                if ((x - 1 < columns && gridArray[x - 1, y]) || gridArrayInUse[x - 1, y] == true)
                    return true;
                else
                    return false;
            // Right
            case "d":
                Debug.Log("D");
                if ((x + 1 < columns && gridArray[x + 1, y]) || gridArrayInUse[x + 1, y] == true)
                    return true;
                else
                    return false;
            default:
                return true;
        }
    }
}