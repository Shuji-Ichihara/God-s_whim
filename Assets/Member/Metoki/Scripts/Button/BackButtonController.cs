using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonController : MonoBehaviour
{
    //シーンチェンジスクリプト
    [SerializeField]
    private SceneChange _sceneChange;
    //表示用のUI
    [SerializeField]
    private Image[] _turtrialImages;
    [SerializeField]
    private Canvas _targetCanvas;

    private int newSortingOrder = 0;
    // Start is called before the first frame update
    public void OnClick()
    {
        if (_turtrialImages[1].enabled)
        {
            _turtrialImages[1].enabled = false;
            _turtrialImages[0].enabled = true;
        }
        else
        {
            _targetCanvas.sortingOrder = newSortingOrder;
            _sceneChange._backButton = true;
            //タイトルシーンに遷移
            _sceneChange.SceneChanges();
        }
    }
}
