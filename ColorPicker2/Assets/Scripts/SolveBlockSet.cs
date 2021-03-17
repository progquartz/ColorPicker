using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveBlockSet : BlockSet
{
    [SerializeField]
    private AnsBlockSet AnswerBlocks;
    

    // AnswerBlocks와 같은지 여부 확인.
    public bool CheckAnswer()
    {
        for(int x = 0; x < MaxX; x++)
        {
            for(int y = 0; y < MaxY; y++)
            {
                if (GetBlockColor(x,y) != AnswerBlocks.GetBlockColor(x, y))
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckAnswer())
        {
            Debug.Log("True");
        }
    }
}
