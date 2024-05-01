using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFilling = false;
    public float fillAmount = 0f;
    public float fillingSpeed = 0.00001f;
    public GridController gridController;
    public PipeType type;
    protected Vector2Int gridPosition = new Vector2Int(0,0);
    public Vector2Int inDir = new Vector2Int(1,0);
    public Vector2Int outDir = new Vector2Int(-1,0);


    void Start()
    {
    inDir  = new Vector2Int( 1, 0);
    outDir = new Vector2Int(-1, 0);
    }
    public void flipInOutDir() 
    {
    Vector2Int tempInDir  = inDir;
    Vector2Int tempOutDir = outDir;
    inDir  = tempOutDir;
    outDir = tempInDir;
    }
    public virtual void startFillingFromTop() 
    {
        gameOver();
    }
    public virtual void startFillingFromRight()
    {
        gameOver();
    }
    public virtual void startFillingFromDown()
    {
        gameOver();
    }
    public virtual void startFillingFromLeft()
    {
        gameOver();
    }
    public void setPosition(Vector2Int pos) 
    {
        transform.position = new Vector3(pos.x,0,pos.y);
        gridPosition = pos;
    }
    public virtual void startNextTile() 
    {
        GameObject pipeGO = gridController.grid[gridPosition.x - outDir.x, gridPosition.y - outDir.y];
        Pipe pipe = pipeGO.GetComponent<Pipe>();
        if (pipe == null) return;
        if(outDir == Vector2Int.up) 
        {
            pipe.startFillingFromDown();
        }else if (outDir == Vector2Int.right)
        {
            pipe.startFillingFromLeft();
        }
        else if(outDir == Vector2Int.down)
        {
            pipe.startFillingFromTop();
        }
        else if(outDir == Vector2Int.left)
        {
            pipe.startFillingFromRight();
        }
    }

    public void gameOver()
    {
        gridController.gameOver();
    }
    public void updatePipe()
    {
        if (!isFilling) return;
        if (isFilling && fillAmount < 1.0f)
        {
            fillAmount += fillingSpeed;
        }
        fillAmount = Mathf.Clamp(fillAmount, 0.0f, 1.0f);
        GetComponent<Renderer>().material.color = Color.Lerp(new Color(1, 1, 1,1),new Color(0,1,0,1),fillAmount);
        if (isFilling && fillAmount >= 1.0f)
        {
            startNextTile();
            isFilling = false;
        }
    }

    public void win()
    {
        gridController.win();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        updatePipe();
    }
}
