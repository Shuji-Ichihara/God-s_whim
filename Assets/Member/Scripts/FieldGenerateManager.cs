using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerateManager : MonoBehaviour
{
    #region Fields
    // フィールドの種類
    [SerializeField]
    private GameObject[] _fieldObjects = { };
    // フィールドオブジェクトがカメラ外に移動する秒数
    public float ScrollTime => _baseScrollTime;
    [SerializeField]
    private float _baseScrollTime = 5f;
    // 経過秒数をキャッシュ
    private float _scrollTime = 0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _scrollTime = _baseScrollTime;
        int firstGenerateFieldCount = 2;
        for (int i = 0; i < firstGenerateFieldCount; i++)
        {
            switch (i)
            {
                case 0:
                    Instantiate(_fieldObjects[0], Vector3.zero, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_fieldObjects[0]
                               , new Vector3(Common.StandardValue * 6f, -Common.StandardValue, 0f)
                               , Quaternion.identity);
                    break;
                default:
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _scrollTime -= Time.deltaTime;
        if (_scrollTime < 0f)
        {
            GenerateField();
        }
    }

    /// <summary>
    /// フィールドをランダム生成する
    /// </summary>
    private void GenerateField()
    {
        var randomNum = Random.Range(0, _fieldObjects.Length);
        Instantiate(_fieldObjects[randomNum]
                   , new Vector3(Common.StandardValue * 6f, -Common.StandardValue, 0f)
                   , Quaternion.identity);
    }

}
