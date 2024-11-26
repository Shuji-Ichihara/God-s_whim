using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchUIController : MonoBehaviour
{

    public float rotationDuration = 5f; // 一周するのにかかる時間
    [SerializeField]
    private GameObject _explsionEffect; // パーティクルエフェクト
    public Image clockImage; // 変更する時計の画像
    public Sprite changedClockSprite; // 変更後の時計画像
    public Sprite originalClockSprite; // 元の時計画像

    private float initialAngle; // 初期の針の角度
    private float rotationSpeed; // 針の回転速度
    private float rKeyPressTime; // Rキーを押している時間を記録
    private bool effectTriggered = false; // エフェクトを一度だけ発生させる
    private bool isCooldown = false; // 針が動かないクールダウン状態か


    void Start()
    {
        // 回転速度を計算
        rotationSpeed = 360f / rotationDuration;
    }

    void Update()
    {
        // クールダウン中は何もしない
        if (isCooldown) return;

        bool isRKeyPressed = Input.GetKey(KeyCode.R);

        if (isRKeyPressed)
        {
            // Rキーを押している間、時計回りに回転
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

            // Rキーを押している時間を記録
            rKeyPressTime += Time.deltaTime;

            // Rキーを5秒間押し続けた場合
            if (rKeyPressTime >= 5f && !effectTriggered)
            {
                TriggerEffect();
            }
        }
        else if (rKeyPressTime > 0f)
        {
            // Rキーを離した場合、記録された時間分だけ反時計回りに戻す
            float remainingRotationTime = rKeyPressTime; // 記録した押下時間を保存

            // 針を反時計回りに戻すコルーチンを開始
            StartCoroutine(RotateBackwards(remainingRotationTime));

            // 時間をリセット
            rKeyPressTime = 0f;
            effectTriggered = false; // エフェクトのリセット
        }
    }

    private System.Collections.IEnumerator RotateBackwards(float time)
    {
        float elapsed = 0f; // 経過時間
        while (elapsed < time)
        {
            // 毎フレーム反時計回りに回転
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, step);

            elapsed += Time.deltaTime;
            yield return null; // 次のフレームまで待機
        }
    }

    private void TriggerEffect()
    {
        // パーティクルを再生
        Instantiate(_explsionEffect, this.transform.position, Quaternion.identity);

        // 時計の画像を変更
        if (clockImage != null && changedClockSprite != null)
        {
            clockImage.sprite = changedClockSprite;
        }

        // 時計の針を初期位置に戻す
        transform.localEulerAngles = new Vector3(0f, 0f, initialAngle);

        // クールダウン開始
        StartCooldown();

        // 5秒後に元に戻す
        Invoke(nameof(ResetClockImage), 5f);

        // エフェクトが一度だけ実行されるようにする
        effectTriggered = true;
    }

    private void StartCooldown()
    {
        isCooldown = true;
        Invoke(nameof(EndCooldown), 5f); // 5秒後にクールダウン解除
    }

    private void EndCooldown()
    {
        isCooldown = false;
    }

    private void ResetClockImage()
    {
        if (clockImage != null && originalClockSprite != null)
        {
            clockImage.sprite = originalClockSprite;
        }
    }
} 



