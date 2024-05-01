using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStreightH : Pipe
{
    void Start()
    {
        inDir  = new Vector2Int(-1, 0);
        outDir = new Vector2Int( 1, 0);
    }
    public override void startFillingFromRight()
    {
        isFilling = true;
        flipInOutDir();
    }
    public override void startFillingFromLeft()
    {
        isFilling = true;
    }
    void FixedUpdate()
    {
        updatePipe();
    }
}

