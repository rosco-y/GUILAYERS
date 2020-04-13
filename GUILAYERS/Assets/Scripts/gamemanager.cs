using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class gamemanager : MonoBehaviour
{

    [SerializeField]
    GameObject _preSudoSheet;
    [SerializeField]
    GameObject SheetsParent;
    [SerializeField]
    Material[] _mSheets;
    float[] yValues;
    float[] xValues;
    float[] zValues;

    #region CONSTRUCTION
    // Start is called before the first frame update
    void Start()
    {
        InstantiateSheets();
    }

    Vector3 UpperLeft;
    /// <summary>
    /// interpolate and place sheets from upper left to (-9, -8, 6);
    /// </summary>
    void InstantiateSheets()
    {
        UpperLeft = new Vector3(20, 10, -10);
        for (int sheet = 0; sheet < g.PUZZLESIZE; sheet++)
        {
            GameObject oSheet = Instantiate(_preSudoSheet);
            oSheet.name = $"Sheet {sheet}";
            print(UpperLeft);
            Vector3 tmp = new Vector3(UpperLeft.x, UpperLeft.y, UpperLeft.z);
            oSheet.transform.position = tmp;
            oSheet.transform.parent = SheetsParent.transform;
            oSheet.GetComponent<MeshRenderer>().material = _mSheets[sheet];
            UpperLeft.x -= 3.18f;
            UpperLeft.y -= 1.5f;
            UpperLeft.z += 2.15f;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
