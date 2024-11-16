using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonController : MonoBehaviour
{
    //シーンチェンジスクリプト
    [SerializeField]
    private SceneChange _sceneChange;
    //表示用のUI
    [SerializeField]
    private Image[] _turtrialImages;
    // Start is called before the first frame update
    public void OnClick()
    {
        //チュートリアルシーンに遷移
        _sceneChange.SceneChanges();        
    }
}
