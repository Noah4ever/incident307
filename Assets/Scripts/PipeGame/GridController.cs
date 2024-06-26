using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject cursor;
    // Width and height of the 2D array
    public int width;
    public int height;
    private Vector2Int cursorPosition;
    private Vector2Int selection;
    // The 2D array of GameObjects
    public GameObject[,] grid;

    void Start()
    {
        cursorPosition = new Vector2Int(0, 0);
        cursor.transform.position = new Vector3(cursorPosition.x,0,cursorPosition.y);
        selection = new Vector2Int(-1, -1);
        // Initialize the array with the specified width and height
        initGrid();
    }

    public void gameOver()
    {
        Debug.Log("GAME OVER!");
    }

    public void win()
    {
        Debug.Log("WIN!");
    }
    void initGrid() 
    {
        PipeType[] tilesTypes = { 
            PipeType.NO_PIPE,    PipeType.NO_PIPE,    PipeType.NO_PIPE,          PipeType.NO_PIPE,           PipeType.NO_PIPE,          PipeType.NO_PIPE,         PipeType.NO_PIPE,
            PipeType.NO_PIPE,    PipeType.STREIGHT_H, PipeType.STREIGHT_H,       PipeType.STREIGHT_V,        PipeType.CORNER_RIGHT_DOWN,       PipeType.CORNER_LEFT_TOP,      PipeType.END_PIPE,
            PipeType.NO_PIPE,    PipeType.CORNER_RIGHT_DOWN, PipeType.STREIGHT_V,       PipeType.STREIGHT_V,        PipeType.CORNER_LEFT_TOP,       PipeType.CORNER_LEFT_TOP,      PipeType.NO_PIPE,
            PipeType.NO_PIPE,    PipeType.STREIGHT_H, PipeType.CORNER_TOP_RIGHT, PipeType.CORNER_RIGHT_DOWN, PipeType.STREIGHT_H, PipeType.CORNER_LEFT_TOP, PipeType.NO_PIPE,
            PipeType.NO_PIPE,    PipeType.CORNER_TOP_RIGHT, PipeType.CORNER_RIGHT_DOWN,       PipeType.STREIGHT_V,        PipeType.STREIGHT_V,       PipeType.CORNER_RIGHT_DOWN,      PipeType.NO_PIPE,
            PipeType.START_PIPE, PipeType.CORNER_TOP_RIGHT, PipeType.STREIGHT_H,       PipeType.CORNER_LEFT_TOP,        PipeType.CORNER_LEFT_TOP,       PipeType.CORNER_LEFT_TOP,      PipeType.NO_PIPE,
            PipeType.NO_PIPE,    PipeType.NO_PIPE,    PipeType.NO_PIPE,          PipeType.NO_PIPE,           PipeType.NO_PIPE,          PipeType.NO_PIPE,         PipeType.NO_PIPE
            };
        grid = new GameObject[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0 || j == 0 || j == height - 1 || i == width - 1) {  
                    GameObject obj = null;
                    obj = GetComponent<PipeFactory>().createPipe(tilesTypes[j * height + height - 1 - i]);
                    obj.GetComponent<Pipe>().setPosition(new Vector2Int(i,j));
                    grid[i, j] = obj;
                }
            }
        }
        for (int i = 1; i < width - 1; i++)
        {
            for (int j = 1; j < height - 1; j++)
            {
                
                    GameObject obj = null;
                    obj = GetComponent<PipeFactory>().createPipe((PipeType)Random.Range(3,8));
                    obj.GetComponent<Pipe>().setPosition(new Vector2Int(i, j));
                    grid[i, j] = obj;
                
            }
        }
    }
    private void Update()
    {
        int horizontalInput = (int)Input.GetAxisRaw("Horizontal");
        int verticalInput = (int)Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal") && horizontalInput > 0)
        {
            // Right
            cursorPosition = cursorPosition + new Vector2Int( 1, 0);
        }else if (Input.GetButtonDown("Vertical") && verticalInput > 0)
        {
            // Up
            cursorPosition = cursorPosition + new Vector2Int(0, 1);
        }
        else if (Input.GetButtonDown("Vertical") && verticalInput < 0)
        {
            // Down
            cursorPosition = cursorPosition + new Vector2Int(0, -1);
        }
        else if (Input.GetButtonDown("Horizontal") && horizontalInput < 0)
        {
            // Left
            cursorPosition = cursorPosition + new Vector2Int(-1, 0);
        }else if (Input.GetButtonDown("Jump")) 
        {
            selectTile(cursorPosition.x, cursorPosition.y);
        }
        cursorPosition = new Vector2Int(Mathf.Clamp(cursorPosition.x,1,width - 2),Mathf.Clamp(cursorPosition.y,1,height - 2));

        cursor.transform.position = new Vector3(cursorPosition.x, 0, cursorPosition.y);
    }
    void deselectTile()
    {
        if(selection.x == -1)
        {
            return;
        }
        Vector3 position = grid[selection.x, selection.y].transform.position;
        grid[selection.x, selection.y].transform.position = new Vector3(position.x, 0, position.z);

        //grid[selection.x, selection.y].GetComponent<MeshRenderer>().material = normalMat;

        selection = Vector2Int.one * -1;
    }
    void swapTiles(int x1,int y1,int x2, int y2) 
    {
        // Store the GameObjects
        GameObject object1 = grid[x1, y1];
        GameObject object2 = grid[x2, y2];

        // Store the world positions of the GameObjects
        Vector3 position1 = object1.transform.position;
        Vector3 position2 = object2.transform.position;

        // Swap the GameObjects in the grid
        grid[x1, y1] = object2;
        grid[x2, y2] = object1;

        // Swap the world positions of the GameObjects
        object1.GetComponent<Pipe>().setPosition(new Vector2Int((int)position2.x,(int)position2.z));
        object2.GetComponent<Pipe>().setPosition(new Vector2Int((int)position1.x, (int)position1.z));
    }
    void selectTile(int x, int y)
    {
        if (grid[x, y] == null) return;
        if (grid[x, y].GetComponent<Pipe>().isFilling) return;

        Vector2Int oldSelection = new Vector2Int(selection.x,selection.y);
        if (selection.x != -1) 
        {
            deselectTile();
            swapTiles(x, y, oldSelection.x, oldSelection.y);
            return;
        }

        Vector3 position = grid[x, y].transform.position;
        grid[x, y].transform.position = new Vector3(position.x, 1, position.z);
        //grid[x, y].GetComponent<MeshRenderer>().material = selectedMat;
        
        selection = new Vector2Int(x, y);
    }
}
