using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonController : MonoBehaviour
{
    //表示用のUI
    [SerializeField]
    private Image[] _turtrialImages;
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
            //タイトルシーンに遷移
        }
    }
}
