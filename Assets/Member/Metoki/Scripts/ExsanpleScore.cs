using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExsanpleScore : MonoBehaviour
{
    //スコア情報を共有できるようにした。
    public static ExsanpleScore Instance { get; private set; }

    private int score = 0;

    public event Action<int> OnMilestoneReached; // 特定スコア到達時のイベント
    //以下テスト用コード。統合する際お役立てください。

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(10);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Current Score: " + score);

        //↓はスコアを加算する際の関数内に残しておいて欲しい
        // 100の倍数を超えた場合にイベントを発火
        if (score % 100 == 0)
        {
            OnMilestoneReached?.Invoke(score);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
