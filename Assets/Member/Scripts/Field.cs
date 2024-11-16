using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Field : MonoBehaviour
{
    /// <summary>
    /// ScrollFieldのラッパー関数
    /// </summary>
    /// <param name="moveSecond">画面をスクロールする秒数</param>
    public void ScrollFieldWrap(float moveSecond)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        ScrollField(moveSecond, cts).Forget();
    }

    /// <summary>
    /// アタッチされているフィールドをスクロールする
    /// </summary>
    /// <param name="moveSecond">画面をスクロールする秒数</param>
    /// <param name="cts"></param>
    /// <returns></returns>
    private async UniTask ScrollField(float moveSecond, CancellationTokenSource cts)
    {
        // アタッチされているフィールドオブジェクトを破棄する座標
        float deleteCoodinateX = -23f;
        while (transform.position.x > deleteCoodinateX)
        {
            // -方向に移動させる為、Vector3.leftを使用。
            transform.position += Vector3.left * (Common.StandardValue * Common.FieldWidth / moveSecond) * Time.deltaTime;
            await UniTask.Yield(cancellationToken: cts.Token);
        }
        Destroy(gameObject);
    }
}
