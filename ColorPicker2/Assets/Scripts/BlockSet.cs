using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSet : MonoBehaviour
{
    [SerializeField]
    private GameObject block;

    public List<GameObject> Blocks;
    public int MaxX;
    public int MaxY;

    // Start is called before the first frame update
    void Start()
    {
        StartBlockSet(MaxX,MaxY);
    }

    /// <summary>
    /// 블럭셋의 설정. 최대 X값과 , 최대 Y값의 데이터를 받아와 설정.
    /// </summary>
    /// <param name="_maxx">최대 X값</param>
    /// <param name="_maxy">최대 Y값</param>
    private void StartBlockSet(int _maxx, int _maxy)
    {
        float blocksize = block.GetComponent<SpriteRenderer>().bounds.size.x;
        Vector3 blockPos = this.transform.position - new Vector3(MaxX * blocksize / 2, MaxY * blocksize / 2);
        Transform BlockTrans = transform.GetChild(0);
        for(int x = 0; x < MaxX; x++)
        {
            for(int y = 0; y < MaxY; y++)
            {
                Blocks.Add(Instantiate(block, blockPos, Quaternion.Euler(0, 0, 0)));
                Blocks[x * MaxY + y].GetComponent<Block>().BasicSet(x, y, Color.white);
                Blocks[x * MaxY + y].transform.SetParent(BlockTrans);
                blockPos += new Vector3(0, blocksize);
            }
            blockPos.y = this.transform.position.y - (MaxY * blocksize / 2);
            blockPos += new Vector3(blocksize, 0);
        }
    }

    public Color GetBlockColor(int x, int y)
    {
        return Blocks[x * MaxY + y].GetComponent<Block>().GetColor();
    }

    public void SetBlockColor(int x, int y, Color _color)
    {
        Blocks[x * MaxY + y].GetComponent<Block>().SetColor(_color);
    }
}
