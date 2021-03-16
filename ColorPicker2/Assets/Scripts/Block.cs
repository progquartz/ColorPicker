using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int x; // x좌표
    public int y; // y좌표

    public Color GetColor()
    {
        return GetComponent<SpriteRenderer>().color;
    }

    public Vector2 GetAxis()
    {
        return new Vector2(x, y);
    }

    public void SetColor(Color _color)
    {
        GetComponent<SpriteRenderer>().color = _color;
    }

    public void BasicSet(int _x, int _y, Color _color)
    {
        x = _x;
        y = _y;
        GetComponent<SpriteRenderer>().color = _color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
