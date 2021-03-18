using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
데이터 받아오는 것

1 (총 주어지는 퍼즐블럭의 수)
3 2 2 (블럭의 총 갯수, 최대 x축, 최대 y축)
0 0 255 0 0 (0이 제일 먼저 나오는 값인 x,y좌표, rgb 값.)
0 1 0 255 0 (0이 제일 먼저 나오는 값인 x,y좌표, rgb 값.)
1 0 0 0 255 (0이 제일 먼저 나오는 값인 x,y좌표, rgb 값.)

 */

public class PuzzleBlockSet : BlockSet
{

    /// <summary>
    /// 해당 포지션에 맞는 블럭 생성.
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_y"></param>
    /// <param name="_color"></param>
    public void CreateBlockFromData(int _x, int _y, Color _color)
    {
        float blocksize = block.GetComponent<SpriteRenderer>().bounds.size.x; // blocksize를 나중에 매니저같은데에다가 보관해서 받아오기 하는게 좋을듯.
        GameObject createdBlock = Instantiate(block, transform.position + new Vector3(_x * blocksize, _y * blocksize), transform.rotation);
        Blocks.Add(createdBlock);
        createdBlock.GetComponent<Block>().SetColor(_color);
        createdBlock.transform.SetParent(blockTrans);

    }

    public int CheckContactCondition()
    {
        Debug.Log(Blocks.Count);
        
        for(int i = 0; i < Blocks.Count; i++)
        {
            if (!Blocks[i].GetComponent<PuzzleBlock>().IsContactValid())
            {
                Debug.Log("checking failed");
                return 0;
            }
        }
        Debug.Log("checking suceeded");
        for (int i = 0; i < Blocks.Count; i++)
        {
            Debug.Log(i + "checking");
            Blocks[i].GetComponent<PuzzleBlock>().ColorPaste();
        }
        return 0;
    }
    private void Start()
    {
        blockTrans= transform.GetChild(0);
        CreateBlockFromData(0, 0, new Color(1, 0, 0));
        CreateBlockFromData(1, 0, new Color(0, 1, 0));
        CreateBlockFromData(0, 1, new Color(0, 0, 1));
    }
}
