using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchUIController : MonoBehaviour
{

    public float cycleTime = 5f; // 半時計回りで一周する時間

    private float maxReverseTime = 5f; // 最大反時計回り時間

    private float reverseElapsedTime = 0f; // ボタンを押していた時間

    private bool isReversing = false; // 半時計回り中かどうか

    private bool isReturning = false; // 戻る途中かどうか

    private float returnElapsedTime = 0f; // 時計回りで戻る際の経過時間

    private float startAngle; // 時計回りで戻る開始時の角度

    private float targetAngle; // 時計回りで戻る目標角度

    private float returnTime; // ボタンを押した時間を基準に戻る時間

    [SerializeField]
    private float _stopWatchTime;
    [SerializeField]
    private bool stopTime = false;
    void Start()
    {
        // 初期位置の回転を保持
        targetAngle = 0f;
    }

    void Update()
    {

            //現状はRキーだが、時を止めている状態を表すフラグ等に変更予定
            if (Input.GetKeyDown(KeyCode.R) && !isReturning)
            {
                StartReversing();
            }

            if (Input.GetKeyUp(KeyCode.R) && !isReturning)
            {
                StartReturning();
            }

            if (isReversing)
            {
                ReverseRotation();
            }

            else if (isReturning)
            {
                ReturnToInitialPosition();
            }

            if (cycleTime == maxReverseTime)
            {
                stopTime = true;
                StartCoroutine(StopTimer());
            }
        
        
    }

    void StartReversing()
    {
        isReversing = true;
        isReturning = false;
        reverseElapsedTime = 0f; // 経過時間をリセット
    }

    void StartReturning()
    {
        isReversing = false;

        isReturning = true;

        returnElapsedTime = 0f; // 経過時間をリセット

        // 現在の針の角度を計算

        startAngle = transform.localEulerAngles.z;

        // ボタンを押していた時間分を元の位置に戻る時間として設定

        returnTime = Mathf.Clamp(reverseElapsedTime, 0f, maxReverseTime);

        if(startAngle > targetAngle)
        {
                targetAngle += 360f;
        }

    }

    void ReverseRotation()
    {
        // 反時計回りの進行度を計算
        reverseElapsedTime += Time.deltaTime;
        float progress = Mathf.Clamp(reverseElapsedTime / cycleTime, 0f, 1f); // 進行度（0-1）
        float angle = progress * 360f; // 半時計回りの角度
        transform.localRotation = Quaternion.Euler(0, 0, -angle); // 反時計回りに回転
    }

    void ReturnToInitialPosition()
    {
        // 経過時間を更新
        returnElapsedTime += Time.deltaTime;
        // 時計回りの進行度を計算
        float progress = Mathf.Clamp01(returnElapsedTime / returnTime); // 進行度（0-1）
        float currentAngle = Mathf.LerpAngle(startAngle, targetAngle, progress); // 線形補間で現在の角度を計算
        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
        // 目標角度に到達したら処理を終了
        if (Mathf.Approximately(progress, 1f))
        {
            isReturning = false;
        }

    }

    IEnumerator StopTimer()
    {
        yield return new WaitForSeconds(_stopWatchTime);
        stopTime = false;
    }

} 



