using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCornerTopRight : Pipe
{
    void Start()
    {
        type = PipeType.CORNER_TOP_RIGHT;
        inDir  = new Vector2Int(0, 1);
        outDir = new Vector2Int(1, 0);
    }
    public override void startFillingFromTop()
    {
        isFilling = true;
    }
    public override void startFillingFromRight()
    {
        isFilling = true;
        flipInOutDir();
    }
    void FixedUpdate()
    {
        updatePipe();
    }
}
