using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerate : MonoBehaviour
{
    // 背景画像をスクロールするスクリプト
    [SerializeField]
    private BackGroundScroll _backGroundSkyImage = null;
    [SerializeField]
    private BackGroundScroll _backGroundForestImage = null;
    // スクロールする秒数
    [SerializeField]
    private float _baseSkyImageScrollTime = 60f;
    [SerializeField]
    private float _baseForestImageScrollTime = 30f;

    // 経過秒数をキャッシュ
    private float _skyImageScrollTime = 0f;
    private float _forestImageScrollTime = 0f;
    // ゲームが始まってから何回画像を生成したかを格納
    // 背景画像を反転してつなぎ合わせる為に使用
    private int _skyImageGenerateCount = 0, _forestImageGenerateCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _skyImageScrollTime = _baseSkyImageScrollTime;
        _forestImageScrollTime = _baseForestImageScrollTime;
        _skyImageGenerateCount = 0;
        _forestImageGenerateCount = 0;
        float skyImageWidth = Common.BackGroundWidth * _backGroundSkyImage.gameObject.transform.localScale.x;
        float forestImageWidth = Common.BackGroundWidth * _backGroundForestImage.gameObject.transform.localScale.x;
        for (int i = 0; i < 2; i++)
        {
            var skyBackGroundScroll  = Instantiate(_backGroundSkyImage
                                                 , new Vector3(skyImageWidth * i, 3f, 0f)
                                                 , Quaternion.AngleAxis(180f * i, Vector3.up));
            skyBackGroundScroll.ScrollBackGroundWrap(_baseSkyImageScrollTime);
            var forestBackGroundScroll = Instantiate(_backGroundForestImage
                                                   , new Vector3(forestImageWidth * i, -5f, 0f)
                                                   , Quaternion.AngleAxis(180f * i, Vector3.up));
            forestBackGroundScroll.ScrollBackGroundWrap (_baseForestImageScrollTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _skyImageScrollTime -= Time.deltaTime;
        _forestImageScrollTime -= Time.deltaTime;
        if (_skyImageScrollTime < 0f)
        {
            GenerateBackGround(in _skyImageGenerateCount, in _skyImageScrollTime, _backGroundSkyImage);
            _skyImageGenerateCount++;
        }
        if( _forestImageScrollTime < 0f)
        {
            GenerateBackGround(in _forestImageGenerateCount, in _forestImageScrollTime, _backGroundForestImage);
            _forestImageGenerateCount++;
        }
    }

    /// <summary>
    /// 背景画像を生成する
    /// </summary>
    /// <param name="generateCount">ゲーム中に何度生成したかをカウントする変数</param>
    /// <param name="scrollTime">スクロールする秒数/param>
    /// <param name="backGround">生成する背景画像</param>
    private void GenerateBackGround(in int generateCount, in float scrollTime, BackGroundScroll backGround)
    {
        BackGroundScroll backGroundScroll = backGround;
        if (generateCount % 2 == 0)
        {
            backGroundScroll = Instantiate(backGround
                                   , new Vector3(Common.StandardValue * Common.FieldWidth, -Common.StandardValue, 0f)
                                   , Quaternion.identity);
        }
        else if (generateCount % 2 == 1)
        {
            backGroundScroll = Instantiate(backGround
                                   , new Vector3(Common.StandardValue * Common.FieldWidth, -Common.StandardValue, 0f)
                                   , Quaternion.AngleAxis(180f, Vector3.up));
        }
        backGroundScroll.ScrollBackGroundWrap(scrollTime);
    }
}
