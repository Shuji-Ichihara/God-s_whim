using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonController : MonoBehaviour
{
    //シーンチェンジスクリプト
    [SerializeField]
    private SceneChange _sceneChange;
    // Start is called before the first frame update
    public void OnClick()
    {
        //次のシーンに遷移
        AudioManager.Instance.PlaySE(SEType.Button);
        _sceneChange.SceneChanges();        
    }
}
