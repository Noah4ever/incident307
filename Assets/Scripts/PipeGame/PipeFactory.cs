using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFactory : MonoBehaviour
{
    public float fillingSpeed = 0.005f;
    public GameObject pipeStreightHorizontal;
    public GameObject pipeCornerTopRight;
    public GameObject pipeNoPipe;
    public GameObject pipeStart;
    public GameObject pipeEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject createPipe(PipeType type) 
    {
        GameObject obj = null;
        switch (type)
        {

            case PipeType.STREIGHT_H:
                obj = Instantiate(pipeStreightHorizontal, transform, true);
                obj.AddComponent<PipeStreightH>();
                break;
            case PipeType.STREIGHT_V:
                obj = Instantiate(pipeStreightHorizontal, transform, true);
                obj.AddComponent<PipeStreightV>();
                obj.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case PipeType.CORNER_TOP_RIGHT:
                obj = Instantiate(pipeCornerTopRight, transform, true);
                obj.AddComponent<PipeCornerTopRight>();
                break;
            case PipeType.CORNER_RIGHT_DOWN:
                obj = Instantiate(pipeCornerTopRight, transform, true);
                obj.AddComponent<PipeCornerRightDown>();
                obj.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case PipeType.CORNER_DOWN_LEFT:
                obj = Instantiate(pipeCornerTopRight, transform, true);
                obj.AddComponent<PipeCornerDownLeft>();
                obj.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case PipeType.CORNER_LEFT_TOP:
                obj = Instantiate(pipeCornerTopRight, transform, true);
                obj.AddComponent<PipeCornerLeftTop>();
                obj.transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
            case PipeType.NO_PIPE:
                obj = Instantiate(pipeNoPipe, transform, true);
                break;
            case PipeType.START_PIPE:
                obj = Instantiate(pipeStart, transform, true);
                obj.GetComponent<Pipe>().startFillingFromTop();
                break;
            case PipeType.END_PIPE:
                obj = Instantiate(pipeEnd, transform, true);
                break;

            default:
                break;
        }
        obj.GetComponent<Pipe>().gridController = GetComponent<GridController>();
        obj.GetComponent<Pipe>().fillingSpeed = fillingSpeed;
        return obj;
    }

}
