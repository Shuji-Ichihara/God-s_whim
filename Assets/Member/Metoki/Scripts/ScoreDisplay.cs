using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _minuteText;

    private void Update()
    {
        //↓ExsanpleScoreは仮に作ったスコア処理なので変える場合
        //ExsanpleScoreの部分も変えてほしいです。
        if (ExsanpleScore.Instance != null)
        {
            int score = ExsanpleScore.Instance.GetScore();
            _scoreText.text = "Score: " + score.ToString();
            _minuteText.text = score.ToString() + "M";

            // スコアを保存
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
        }
    }

}
