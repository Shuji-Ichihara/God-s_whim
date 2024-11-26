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
        if (ExsanpleScore.Instance != null)
        {
            _scoreText.text = "Score: " + ExsanpleScore.Instance.GetScore().ToString();
            _minuteText.text = ExsanpleScore.Instance.GetScore().ToString() + "M";
        }
    }

}
