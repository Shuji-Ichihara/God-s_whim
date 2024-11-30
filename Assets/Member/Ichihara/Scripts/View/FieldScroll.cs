using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class FieldScroll : MonoBehaviour
{
    //
    private List<SpriteRenderer> _renderers = new List<SpriteRenderer>();

    private void Start()
    {
        // 子オブジェクト全てのSpriteRendererコンポーネントを取得
        // 空のオブジェクトはTransform属性しか保持していない為
        var parentList = GetComponentsInChildren<Transform>().Where(transform => !transform.name.Contains("Gimmick"));
        for (int i = 0; i < parentList.Count(); i++)
        {
            foreach (var child in parentList)
            {
                var childList = child.GetComponents<SpriteRenderer>()
                                     .ToList();
                _renderers.AddRange(childList);
            }
        }
    }

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
            try
            {
                // 時間停止フラグが真の場合、while文を待機する
                // 時を止める処理と演出を行う
                if (GameManager.Instance.TimeStop == true)
                {
                    await TimeStopManager.Instance.StopSeconds(_renderers);
                }
                // -方向に移動させる為、Vector3.leftを使用。
                transform.position += Vector3.left * (Common.StandardValue * Common.FieldWidth / moveSecond) * Time.deltaTime;
                await UniTask.Yield(cancellationToken: cts.Token);
            }
            catch (MissingComponentException)
            {
                throw;
            }
            if (GameManager.Instance.GameOver == true) return;
        }
        Destroy(gameObject);
    }
}
