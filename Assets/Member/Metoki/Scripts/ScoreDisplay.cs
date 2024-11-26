using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _minuteText;
    [SerializeField] private TextMeshProUGUI milestoneText;   // 節目メッセージ表示用

    private void Start()
    {
        // ScoreManagerのイベントを購読
        if (ExsanpleScore.Instance != null)
        {
            ExsanpleScore.Instance.OnMilestoneReached += ShowMilestoneMessage;
        }

        // 節目メッセージを非表示にしておく
        milestoneText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (ExsanpleScore.Instance != null)
        {
            _scoreText.text = "Score: " + ExsanpleScore.Instance.GetScore().ToString();
            _minuteText.text = ExsanpleScore.Instance.GetScore().ToString() + "M";
        }
    }

    private void ShowMilestoneMessage(int milestoneScore)
    {
        // 節目メッセージの更新と表示
        milestoneText.text = $"{milestoneScore}m到達!";
        milestoneText.gameObject.SetActive(true);

        // 2秒後に非表示
        Invoke(nameof(HideMilestoneMessage), 2f);
    }

    private void HideMilestoneMessage()
    {
        milestoneText.gameObject.SetActive(false);
    }
}
