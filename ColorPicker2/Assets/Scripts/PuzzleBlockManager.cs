using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlockManager : MonoBehaviour
{
    [SerializeField]
    private GameObject block;
    private List<GameObject> PuzzleBlockSets = new List<GameObject>();

    /// <summary>
    /// 블럭들을 인덱스에 맞게 재정렬하는 코드
    /// </summary>
    public void RearrangeBlockSets()
    {
        float blocksize = block.GetComponent<SpriteRenderer>().bounds.size.x;
        Vector3 blocksetpos = transform.position;

        for(int i = 0; i < PuzzleBlockSets.Count; i++)
        {
            // 인스턴싱하면서 맥스x만큼 옆으로 움직이면서 인스턴싱.
        }
    }
}
