using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEnd : Pipe
{
    void Start()
    {
        inDir = new Vector2Int(0, 0);
        outDir = new Vector2Int(0, 0);
    }
    public override void startFillingFromTop()
    {
        isFilling = true;
        win();
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
    public override void startNextTile(){}
    void FixedUpdate()
    {
        updatePipe();
    }
}
