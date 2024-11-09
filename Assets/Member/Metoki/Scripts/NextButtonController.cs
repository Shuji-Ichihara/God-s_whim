using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonController : MonoBehaviour
{
    //シーンチェンジスクリプト
    [SerializeField]
    private SceneChange _sceneChange;
    //表示用のUI
    [SerializeField]
    private Image[] _turtrialImages;
    public void OnClick()
    {
        if (_turtrialImages[0].enabled)
        {
            _turtrialImages[0].enabled = false;
            _turtrialImages[1].enabled = true;
        }
        else
        {
            //プレイシーンに遷移
            _sceneChange.SceneChanges();
        }
    }
}
