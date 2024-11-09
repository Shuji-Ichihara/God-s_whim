using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonController : MonoBehaviour
{
    //表示用のUI
    [SerializeField]
    private Image[] _turtrialImages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        }
    }
}
