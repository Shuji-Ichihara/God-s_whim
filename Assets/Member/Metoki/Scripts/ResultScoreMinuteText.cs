using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScoreMinuteText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _minuteText;

    private void Start()
    {
        // 保存されたスコアを取得
        int savedScore = PlayerPrefs.GetInt("Score", 0);

        // テキストに表示
        _scoreText.text = "Score: " + savedScore.ToString();
        _minuteText.text = savedScore.ToString() + "M";
    }
}
