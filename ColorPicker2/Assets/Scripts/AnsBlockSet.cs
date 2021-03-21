using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsBlockSet : BlockSet
{
    public static AnsBlockSet instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    public void GetData()
    {
        for (int x = 0; x < DataParser.instance.MaxCoord.x; x++)
        {
            for (int y = 0; y < DataParser.instance.MaxCoord.y; y++)
            {
                SetBlockColor(x, y, DataParser.instance.AnsColor[x + y * (int)DataParser.instance.MaxCoord.x]);
            }
        }
    }

}
