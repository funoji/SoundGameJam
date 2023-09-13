using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Text TimerText;
    [SerializeField] float Timer = 100;

    // Start is called before the first frame update
    void Start()
    {
        // 最初のテキスト表示を設定
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        // タイマーが0以下にならないように制限
        if (Timer < 0)
        {
            SceneManager.LoadScene("result");
        }

        // タイマーのテキストを更新
        UpdateTimerText();
    }

    // タイマーのテキストを更新する関数
    void UpdateTimerText()
    {
        // TimerTextに残り時間を表示
        TimerText.text = Timer.ToString("F1"); // "F1" は小数点以下1桁まで表示するフォーマット
    }
}