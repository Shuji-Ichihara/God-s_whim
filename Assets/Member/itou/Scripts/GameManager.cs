using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool _skillcooltime = false;
    public bool _timestop = false;
    private float _survivalTime = 0;
    private float _survivalScore = 0;
    private int _survivalResultScore = 0;
    public int _scoremagnification = 0;
    [SerializeField]
    private GameObject _skillUI;
    [SerializeField]
    private Text _survivaTimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _survivalTime += Time.deltaTime;
        _survivalScore = _survivalTime * _scoremagnification;
        _survivalResultScore = (int)_survivalScore;
        _survivaTimeText.text = "SCORE:" + _survivalScore.ToString("n0");
    }

    public void Timestop()
    {
        _timestop = true;
    }

    public IEnumerator Skillcooltime()
    {
        _skillcooltime = true;
        _skillUI.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _skillcooltime = false;
        _skillUI.SetActive(true);
    }
}

//参考サイト
//