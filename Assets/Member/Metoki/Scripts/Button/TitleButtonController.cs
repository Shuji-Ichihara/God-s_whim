using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonController : MonoBehaviour
{
    //シーンチェンジスクリプト
    [SerializeField]
    private SceneChange _sceneChange;
    [SerializeField]
    private Canvas _targetCanvas;

    private int newSortingOrder = 0;
    // Start is called before the first frame update
    public void OnClick()
    {
        _targetCanvas.sortingOrder = newSortingOrder;
        //次のシーンに遷移
        _sceneChange.SceneChanges();        
    }
}
