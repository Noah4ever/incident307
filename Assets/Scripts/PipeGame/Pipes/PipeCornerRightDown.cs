using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCornerRightDown : Pipe
{
    void Start()
    {
        init();
        type = PipeType.CORNER_RIGHT_DOWN;
        inDir  = Vector2Int.right;
        outDir = Vector2Int.down;
    }
    public override void startFillingFromTop()
    {
        gameOver();
    }
    public override void startFillingFromRight()
    {
        isFilling = true;
    }
    public override void startFillingFromDown()
    {
        isFilling = true;
        flipInOutDir();
    }
    public override void startFillingFromLeft()
    {
        gameOver();
    }
    void FixedUpdate()
    {
        updatePipe();
    }
}