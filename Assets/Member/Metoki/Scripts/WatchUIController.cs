using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class WatchUIController : MonoBehaviour
{
    // 時計のボタン
    [SerializeField]
    private Button _clockButton;
    [SerializeField]
    private Transform _clockNeedle;
    [SerializeField, Header("一周するのにかかる時間")] private float _rotationDuration;
    [SerializeField, Header("クールダウンにかかる時間")] private float _coolDownDuration;
    [SerializeField]
    private GameObject _explsionEffect; // パーティクルエフェクト
    [SerializeField]
    private Image _clockImage; // 時計の画像
    [SerializeField]
    private Sprite _changedClockSprite; // 変更後の時計画像
    [SerializeField]
    private Sprite _originalClockSprite; // 元の時計画像

    private float _rotationSpeed; // 針の回転速度

    private bool _isRotating = false; // 回転してるかどうか
    private bool _isCooldown = false; // 針が動かないクールダウン状態か


    void Start()
    {
        // 回転速度を計算
        _rotationSpeed = 360f / _rotationDuration;

        //ボタンのクリックイベントに関数を登録
        if(_clockButton != null )
        {
            _clockButton.onClick.AddListener(OnClickButtonPressed);
        }
    }

    void Update()
    {
        //回転中なら針を時計回りに回す
        if(_isRotating)
        {
            RotateClockwise();
        }
    }

    //時計のボタンが押された際に呼び出される処理
    private void OnClickButtonPressed()
    {
        if(!_isCooldown && !_isRotating)
        {
            _isRotating = true;
            StartCoroutine(CompleteRotation());
        }
    }

    //針を時計回りに回転させる処理
    private void RotateClockwise()
    {
        if(_clockNeedle != null)
        {
            //毎フレーム指定した速度で回転
            _clockNeedle.Rotate(Vector3.forward, -_rotationSpeed * Time.deltaTime);
        }
    }
    //一周するまで針を回転させる
    private System.Collections.IEnumerator CompleteRotation()
    {
        float elpsed = 0;
        //指定した経過時間まで処理をループ
        while (elpsed < _rotationDuration)
        {
            elpsed += Time.deltaTime;
            yield return null;
        }
        _isRotating = false;
        TriggerEffect();
    }

    //一周後の画像変更やエフェクト発生等を行う処理
    private void TriggerEffect()
    {
        
        // パーティクルを再生
        Instantiate(_explsionEffect, this.transform.position, Quaternion.identity);

        // 時計の画像を変更
        if (_clockImage != null && _changedClockSprite != null)
        {
            _clockImage.sprite = _changedClockSprite;
        }

        // クールダウン開始
        StartCooldown();

        // 5秒後に元に戻す
        Invoke(nameof(ResetClockImage), 5f);

    }
    //クールダウン開始
    private void StartCooldown()
    {
        _isCooldown = true;
        Invoke(nameof(EndCooldown), _coolDownDuration); // n秒後にクールダウン解除
    }
    //クールダウン終了
    private void EndCooldown()
    {
        _isCooldown = false;
    }
    //時計の画像を元に戻す
    private void ResetClockImage()
    {
        if (_clockImage != null && _originalClockSprite != null)
        {
            _clockImage.sprite = _originalClockSprite;
        }
    }
} 



