using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : Block
{
    private Transform puzzleBlockSet;
    [SerializeField]
    private GameObject colorTargetBlock;
    [SerializeField]
    private bool isContacted = false;
    
    public bool IsContactValid()
    {
        return isContacted;
    }

    // 블럭터치됨.
    private void Start()
    {
        puzzleBlockSet = transform.parent.parent;
    }
    private void OnMouseDown()
    {
        //Debug.Log("mousedown");
    }

    private void OnMouseDrag()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        puzzleBlockSet.position += new Vector3(worldPosition.x, worldPosition.y, 0) - transform.position;
    }

    // 블럭 터치 풀림.
    private void OnMouseUp()
    {
        puzzleBlockSet.gameObject.GetComponent<PuzzleBlockSet>().CheckContactCondition();
        Debug.Log("mouseup");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            isContacted = true;
            if(colorTargetBlock != collision.gameObject || colorTargetBlock == null)
            {
                colorTargetBlock = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Block")
        {
            isContacted = false;
        }
    }

    /// <summary>
    /// 현재 자신 아래에 있는 블럭에 해당하는 연산을 실행시켜 색깔을 덮어씌움.
    /// </summary>
    public void ColorPaste()
    {
        Color targetcolor = colorTargetBlock.GetComponent<Block>().GetColor() + this.GetComponent<Block>().GetColor();
        colorTargetBlock.GetComponent<Block>().SetColor(targetcolor);
    }


    // 마우스 들어왔을때 겉테두리 active 되게 만들기.
    private void OnMouseEnter()
    {
        
    }

    // 마우스 나갈때 겉테두리 deactive 되게 만들기.
    private void OnMouseExit()
    {
        
    }
}
