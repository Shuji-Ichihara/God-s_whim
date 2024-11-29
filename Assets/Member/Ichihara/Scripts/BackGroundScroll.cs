using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    private SpriteRenderer _renderer = null;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// ScrollBackGroundのラッパー関数
    /// </summary>
    /// <param name="moveSecond">画面をスクロールする秒数</param>
    public void ScrollBackGroundWrap(float moveSecond)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        ScrollBackGrond(moveSecond, cts).Forget();
    }

    /// <summary>
    /// 背景画像をスクロールする
    /// </summary>
    /// <param name="moveSecond">画面をスクロールする秒数</param>
    /// <param name="cts"></param>
    /// <returns></returns>
    private async UniTask ScrollBackGrond(float moveSecond, CancellationTokenSource cts)
    {
        float backGroundImageWidth = Common.BackGroundWidth * transform.localScale.x;
        // アタッチされているフィールドオブジェクトを破棄する座標
        float deleteCoodinateX = -23f;
        while (transform.position.x > deleteCoodinateX)
        {
            // 時間停止フラグが真の場合、while文を待機する
            // 時を止める処理と演出を行う
            if (GameManager.Instance._timestop == true)
            {
                await TimeStopManager.Instance.StopSeconds(_renderer);
            }
            // -方向に移動させる為、Vector3.leftを使用。
            transform.position += Vector3.left * (Common.BackGroundWidth / moveSecond) * Time.deltaTime;
            await UniTask.Yield(cancellationToken: cts.Token);
        }
        Destroy(gameObject);
    }
}
