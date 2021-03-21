using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataParser : MonoBehaviour
{
    public static DataParser instance;

    private string m_strPath = "StageData/";

    // 데이터 저장
    public List<string[]> Data = new List<string[]>();
    public Vector2 MaxCoord = new Vector2();
    public List<Color> AnsColor = new List<Color>();
    public List<Color> SolveColor = new List<Color>();
    public int PuzzleBlockCount;
    public List<Vector2> PuzzleBlockMaxCoord = new List<Vector2>();
    public List<List<Vector2>> PuzzleBlockCoords = new List<List<Vector2>>();
    public List<List<Color>> PuzzleBlockColors = new List<List<Color>>();

    private void Awake()
    {
        if(instance == null || instance != this)
        {
            instance = this;
        }
    }

    private void Start()
    {
        DataParse();
        BlockDataring();
        SolveBlockSet.instance.GetData();
        AnsBlockSet.instance.GetData();
    }
    public void DataParse()
    {
        TextAsset parseData = Resources.Load(m_strPath + "Stage0", typeof(TextAsset)) as TextAsset;
        if(parseData == null)
        {
            Debug.Log("실패");
        }
        StringReader sr = new StringReader(parseData.text);

        // 먼저 한줄을 읽는다.
        string source = sr.ReadLine();
        string[] values;
        while (source != null)

        {
            values = source.Split(' ');  // 스페이스로 구분한다.
            Data.Add(values);
            if (values.Length == 0)

            {
                sr.Close();
                return;
            }
            source = sr.ReadLine();    // 한줄 읽는다.
        }

        // 여기서부턴 단순 파싱한 데이터 찍어주는곳.

    }

    /// <summary>
    /// 블럭 데이터들 전부 모아모아하기
    /// </summary>
    private void BlockDataring()
    {
        MaxCoord.x = float.Parse(Data[0][0]);
        MaxCoord.y = float.Parse(Data[0][1]);
        int index = 1;
        for(int y = 0; y < MaxCoord.y; y++)
        {
            for(int x = 0; x < MaxCoord.x; x++)
            {
                AnsColor.Add(new Color(float.Parse(Data[index][0]), float.Parse(Data[index][1]), float.Parse(Data[index][2])));
                index++;
            }
        }
        MaxCoord.x = float.Parse(Data[index][0]);
        MaxCoord.y = float.Parse(Data[index++][1]);
        //index++;
        for (int y = 0; y < MaxCoord.y; y++)
        {
            for (int x = 0; x < MaxCoord.x; x++)
            {
                SolveColor.Add(new Color(float.Parse(Data[index][0]), float.Parse(Data[index][1]), float.Parse(Data[index][2])));
                index++;
            }
        }
        //public List<List<Vector2>> PuzzleBlockCoord = new List<List<Vector2>>();
        //public List<List<Color>> PuzzleBlockColor = new List<List<Color>>();
        /*
        데이터 받아오는 것
        1 (총 주어지는 퍼즐블럭의 수)
        3 2 2 (블럭의 총 갯수, 최대 x축, 최대 y축)
        0 0 255 0 0 (0이 제일 먼저 나오는 값인 x,y좌표, rgb 값.)
        0 1 0 255 0 (0이 제일 먼저 나오는 값인 x,y좌표, rgb 값.)
        1 0 0 0 255 (0이 제일 먼저 나오는 값인 x,y좌표, rgb 값.)
         */

        PuzzleBlockCount = int.Parse(Data[index++][0]);
        for(int cnt = 0; cnt < PuzzleBlockCount; cnt++) // 블럭 종류 갯수만큼
        {
            int blockcnt = int.Parse(Data[index][0]);
            Vector2 maxCoord = new Vector2(int.Parse(Data[index][1]), int.Parse(Data[index][2]));
            index++;
            List<Vector2> puzzleblockVec2 = new List<Vector2>();
            List<Color> puzzleBlockColor = new List<Color>();
            for (int i = 0; i < blockcnt; i++)
            {
                puzzleblockVec2.Add(new Vector2(int.Parse(Data[index][0]), int.Parse(Data[index][1])));
                puzzleBlockColor.Add(new Color(float.Parse(Data[index][2]), float.Parse(Data[index][3]), float.Parse(Data[index][4])));
                index++;
            }
            PuzzleBlockMaxCoord.Add(maxCoord);
            PuzzleBlockColors.Add(puzzleBlockColor);
            PuzzleBlockCoords.Add(puzzleblockVec2);
        }

}

}
