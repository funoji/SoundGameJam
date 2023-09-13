using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject combocounter;
    [SerializeField] Text Currentcombo; // 現在のコンボ数を表示するTextコンポーネント
    [SerializeField] Text Maxcombo; // 最大コンボ数を表示するTextコンポーネント

    private int combo = 0;
    private int maxCombo = 0;

    // OnTriggerEnterはトリガーコリジョンに他のコライダーが侵入した瞬間に呼び出されます
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == combocounter)
        {
            // 'combocount'に当たった場合、コンボを加算
            combo++;

            // 最大コンボ数を更新
            if (combo > maxCombo)
            {
                maxCombo = combo;
            }

            // コンボ数をTextコンポーネントに表示
            if (Currentcombo != null)
            {
                Currentcombo.text = "Combo: " + combo.ToString();
            }
        }
        else if (other.gameObject == player)
        {
            // 'player'に当たった場合、コンボをリセット
            combo = 0;

            // リセット後のコンボ数をTextコンポーネントに表示
            if (Currentcombo != null)
            {
                Currentcombo.text = "Combo: " + combo.ToString();
            }
        }

        // 最大コンボ数をTextコンポーネントに表示
        if (Maxcombo != null)
        {
            Maxcombo.text = "Max Combo: " + maxCombo.ToString();
        }
    }

    // 他のコードから最大コンボ数を取得するためのメソッド
    public int GetMaxCombo()
    {
        return maxCombo;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        combo = 0;
        maxCombo = 0;

        // Textコンポーネントに初期値を設定
        if (Currentcombo != null)
        {
            Currentcombo.text = "Combo: " + combo.ToString();
        }
        if (Maxcombo != null)
        {
            Maxcombo.text = "Max Combo: " + maxCombo.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ここに必要な処理を追加
    }
}