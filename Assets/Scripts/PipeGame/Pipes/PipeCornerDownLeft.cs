using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCornerDownLeft : Pipe
{
    void Start()
    {
        type = PipeType.CORNER_DOWN_LEFT;
        inDir  = new Vector2Int(0, -1);
        outDir = new Vector2Int(-1, 0);
    }
    public override void startFillingFromDown()
    {

        isFilling = true;
    }
    public override void startFillingFromLeft()
    {
        isFilling = true;
        flipInOutDir();
    }
    void FixedUpdate()
    {
        updatePipe();
    }
}
