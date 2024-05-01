using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStreightV : Pipe
{
    void Start()
    {
        type = PipeType.STREIGHT_V;
        inDir  = new Vector2Int(0, 1);
        outDir = new Vector2Int(0, -1);
    }
    public override void startFillingFromTop()
    {
        isFilling = true;
    }
    public override void startFillingFromRight()
    {
        gameOver();
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
