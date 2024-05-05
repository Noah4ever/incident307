using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNoPipe : Pipe
{
    void Start()
    {
        init();
        inDir  = new Vector2Int(0, 0);
        outDir = new Vector2Int(0, 0);
        type = PipeType.NO_PIPE;
    }
    public override void startFillingFromTop()
    {
        gameOver();
    }
    public override void startFillingFromRight()
    {
        gameOver();
    }
    public override void startFillingFromDown()
    {
        gameOver();
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

