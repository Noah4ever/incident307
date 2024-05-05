using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCornerLeftTop : Pipe
{
    void Start()
    {
        init();
        type = PipeType.CORNER_LEFT_TOP;
        inDir = new Vector2Int(-1, 0);
        outDir = new Vector2Int(0, 1);
    }
    public override void startFillingFromTop()
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
