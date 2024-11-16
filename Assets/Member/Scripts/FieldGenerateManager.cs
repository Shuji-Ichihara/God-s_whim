using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerateManager : MonoBehaviour
{
    #region Fields
    // フィールドの種類
    [SerializeField]
    private Field[] _fieldObjects = { };
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
        int firstGenerateFieldCount = 3;
        for (int i = 0; i < firstGenerateFieldCount; i++)
        {
            switch (i)
            {
                case 0:
                    var firstField = Instantiate(_fieldObjects[0]
                                               , Vector3.down * Common.StandardValue
                                               , Quaternion.identity);
                    firstField.ScrollFieldWrap(_baseScrollTime);
                    break;
                case 1:
                    var secondField = Instantiate(_fieldObjects[0]
                                               , new Vector3(Common.StandardValue * Common.FieldWidth, -Common.StandardValue, 0f)
                                               , Quaternion.identity);
                    secondField.ScrollFieldWrap(_baseScrollTime);
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
            _scrollTime = _baseScrollTime;
        }
    }

    /// <summary>
    /// フィールドをランダム生成する
    /// </summary>
    private void GenerateField()
    {
        int randomNum = Random.Range(0, _fieldObjects.Length);
        var field = Instantiate(_fieldObjects[randomNum]
                               , new Vector3(Common.StandardValue * Common.FieldWidth, -Common.StandardValue, 0f)
                               , Quaternion.identity);
        field.ScrollFieldWrap(_baseScrollTime);
    }

}
