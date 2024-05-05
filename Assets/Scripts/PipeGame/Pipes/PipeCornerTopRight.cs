using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCornerTopRight : Pipe
{
    void Start()
    {
        init();
        inDir  = new Vector2Int(0, 1);
        outDir = new Vector2Int(1, 0);
        type = PipeType.CORNER_TOP_RIGHT;
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
