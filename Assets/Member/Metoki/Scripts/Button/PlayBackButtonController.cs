using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackButtonController : MonoBehaviour
{
    //シーンチェンジスクリプト
    [SerializeField]
    private SceneChange _sceneChange;
    // Start is called before the first frame update
    public void OnClick()
    {
        _sceneChange._backButton = true;
        //次のシーンに遷移
        _sceneChange.SceneChanges();
    }
}
