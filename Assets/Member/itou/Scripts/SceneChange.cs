using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneChange : MonoBehaviour
{
    [SerializeField] List<string> SceneName = new List<string>();
    GameObject ManageObject;
    FadeScene fadeSceneManager;
    public bool Happyend;
    //目時追加
    public bool _backButton;
    int ChangeClick;
    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManagerがアタッチされているオブジェクトを取得
        ManageObject = GameObject.Find("SceneChangeObject");
        //オブジェクトの中のSceneFadeManagerを取得
        fadeSceneManager = ManageObject.GetComponent<FadeScene>();
        ChangeClick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != SceneName[1])
        {
            if (Input.GetKeyDown(KeyCode.Space) && ChangeClick == 0)
            {
                ChangeClick++;
                //SceneFadeManagerがアタッチされているオブジェクトを取得
                ManageObject = GameObject.Find("SceneChangeObject");
                //オブジェクトの中のSceneFadeManagerを取得
                fadeSceneManager = ManageObject.GetComponent<FadeScene>();
                SceneChanges();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q) && ChangeClick == 0)
            {
                ChangeClick++;
                SceneChanges();
            }
        }
    }

    public void SceneChanges()
    {
        if (SceneManager.GetActiveScene().name == SceneName[1])
        {
            //目時改定(シーン遷移の分岐条件を変更)
            if (_backButton == false)
            {
                //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[2]);                
            }
            else if (_backButton == true)
            {
                //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
                _backButton = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == SceneName[0])
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[1]);
        }
        else if (SceneManager.GetActiveScene().name == SceneName[2])
        {
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
            fadeSceneManager.Destorycount += 1;
        }
        else if (SceneManager.GetActiveScene().name == SceneName[3])
        {
            //目時改定(シーン遷移の分岐条件を変更)
            if (_backButton == false)
            {
                //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
            }
            else if (_backButton == true)
            {
                //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
                fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[2]);
                _backButton = false;
            }
            //SceneFadeManagerの中のフェードアウト開始関数を呼び出し
            //fadeSceneManager.fadeOutStart(0, 0, 0, 0, SceneName[0]);
            //fadeSceneManager.Destorycount += 1;
        }
    }
}
