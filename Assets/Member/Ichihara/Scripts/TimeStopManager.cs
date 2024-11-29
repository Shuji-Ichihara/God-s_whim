using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeStopManager : MonoBehaviour
{
    public static TimeStopManager Instance { get => _instance; }
    private static TimeStopManager _instance;

    // 時を止める秒数
    [SerializeField, Range(0f, 2f)]
    private float _stopSecondsCount = 1f;
    // 時を止めた時の演出
    // 変更前/変更後のマテリアル
    [SerializeField]
    private Material _beforeMaterial = null, _afterMaterial = null;

    private void Start()
    {
        _instance ??= this;
    }

    /// <summary>
    /// 時を止める処理
    /// </summary>
    /// <param name="renderers"></param>
    /// <returns></returns>
    public async UniTask StopSeconds(List<SpriteRenderer> renderers)
    {
        // マテリアルを変更する
        foreach (var renderer in renderers)
        {
            ChangeMaterial(renderer, _afterMaterial);
        }
        await UniTask.WaitForSeconds(_stopSecondsCount, cancellationToken: new CancellationTokenSource().Token);
        // マテリアルを元に戻す
        foreach (var renderer in renderers)
        {
            ChangeMaterial(renderer, _beforeMaterial);
        }
    }

    /// <summary>
    /// 時を止める演出
    /// </summary>
    /// <param name="renderer">マテリアルを適用するSpriteRenderer</param>
    /// <param name="material">変更するマテリアル</param>
    private void ChangeMaterial(SpriteRenderer renderer, Material material)
    {
        renderer.material = material;
    }
}
