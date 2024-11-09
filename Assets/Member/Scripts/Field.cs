using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Field : MonoBehaviour
{
    public void MoveFieldWrap(float moveTime)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        MoveField(moveTime, cts).Forget();
    }

    private async UniTask MoveField(float moveTime, CancellationTokenSource cts)
    {
        // アタッチされているフィールドオブジェクトを破棄する座標
        float deleteCoodinateX = -23f;
        while (transform.position.x > deleteCoodinateX)
        {
            // -方向に移動させる為、Vector3.leftを使用。
            transform.position += Vector3.left * (Common.StandardValue * Common.FieldWidth / moveTime) * Time.deltaTime;
            await UniTask.Yield(cancellationToken: cts.Token);
        }
        Destroy(gameObject);
    }
}
