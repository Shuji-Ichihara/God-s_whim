using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterEffectResultText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textComponent; // 表示させるTextMeshProUGUI
    [SerializeField] private float _typingSpeed = 0.05f;    // 文字が表示される間隔

    private string _fullText; // 全文を格納する変数
    private string _currentText = ""; // 現在表示中のテキスト

    private void Start()
    {
        // TextMeshProコンポーネントから全文を取得
        _fullText = _textComponent.text;

        // 最初は空文字を表示
        _textComponent.text = "";

        // タイピングエフェクト開始
        StartCoroutine(DisplayText());
    }

    private System.Collections.IEnumerator DisplayText()
    {
        for (int i = 0; i < _fullText.Length; i++)
        {
            _currentText += _fullText[i]; // 一文字ずつ追加
            _textComponent.text = _currentText; // テキストを更新

            yield return new WaitForSeconds(_typingSpeed); // 指定時間待機
        }
    }
}
