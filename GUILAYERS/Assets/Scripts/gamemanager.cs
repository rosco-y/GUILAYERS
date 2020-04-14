using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;
using Assets.Scripts.MODEL;

public class gamemanager : MonoBehaviour
{

    [SerializeField]
    GameObject _preSudoSheet;
    [SerializeField]
    cSudoSheet _cSudoSheet;
    [SerializeField]
    GameObject SheetsParent;
    [SerializeField]
    Material[] _mSheets;
    float[] yValues;
    float[] xValues;
    float[] zValues;
    cData _puzzleData;
    #region CONSTRUCTION
    // Start is called before the first frame update
    void Start()
    {
        InstantiateSheets();
        _puzzleData = new cData();
        _puzzleData.ReadData();
    }

    Vector3 UpperLeft;
    /// <summary>
    /// interpolate and place sheets from upper left to roughly (-9, -8, 6);
    /// </summary>
    void InstantiateSheets()
    {
        Vector3[] pos;
        Vector3[] scale;
        InitizlizePositionAndScaleArrays(out pos, out scale);
        // UpperLeft = new Vector3(20, 10, -10);
        for (int sheet = 0; sheet < g.PUZZLESIZE; sheet++)
        {
            cSudoSheet oSheet = Instantiate(_cSudoSheet);
            oSheet.name = $"Sheet {sheet}";
            print(UpperLeft);
            oSheet.transform.position = pos[sheet];
            oSheet.transform.localScale = scale[sheet];
            oSheet.transform.parent = SheetsParent.transform;
            oSheet.GetComponent<MeshRenderer>().material = _mSheets[sheet];
            //UpperLeft.x -= 3.18f;
            //UpperLeft.y -= 1.5f;
            //UpperLeft.z += 2.15f;
        }
    }

    private void InitizlizePositionAndScaleArrays(out Vector3[] pos, out Vector3[] scale)
    {
        pos = new[]  
        {
           new Vector3(23.13F,-1.16F,-11.83F),
           new Vector3 (20.13F, -3.76F, -9.83F),
           new Vector3(20F,0F,-8.2F),
           new Vector3( 46.23F,-8.76F,-8.13F), //3
           new Vector3(12.73F,-11.96F,-6.05F),
           new Vector3(7.14F,-9.7F,-3.83F),
           new Vector3(2.64F,-15.34F,-1.83F),
           new Vector3(1.51F,-13.69F,0.38F),
           new Vector3(-9.4F,-10.9F,2.53F)
           //new Vector3(-7.91f,-5.93f,6.36f) 
        };
        //pos = Opos;

        //Vector3[] Oscale = new[]
        scale = new[]
        {
            new Vector3(1f,1f,1f),
            new Vector3(1f,1f,1f),
            new Vector3(1f,1f,1f),
            new Vector3(1f,1f,1f),
            new Vector3(1.07f,1.07f,1.07f),
            new Vector3(1.18f,1.18f,1.18f),
            new Vector3(1.5f,1.5f,1.5f),
            new Vector3(1.7f,1.7f,1.7f),
            new Vector3(1.34f,1.34f,1.34f) 
        };
//        scale = 0scale;
    }

}
#endregion


