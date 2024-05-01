using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStart : Pipe
{
    void Start()
    {
        inDir = new Vector2Int(0, 0);
        outDir = new Vector2Int(1, 0);
        type = PipeType.START_PIPE;
    }
    public override void startFillingFromTop()
    {
        isFilling = true;
    }
    public override void startFillingFromRight()
    {
        startFillingFromTop();
    }
    public override void startFillingFromDown()
    {
        startFillingFromTop();
    }
    public override void startFillingFromLeft()
    {
        startFillingFromTop();
    }
    void FixedUpdate()
    {
        updatePipe();
    }
}

