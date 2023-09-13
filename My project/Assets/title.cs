using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    [SerializeField] GameObject titleImage; // タイトル画像を格納するGameObject
    [SerializeField] GameObject howtoImage; // 操作説明画像を格納するGameObject

    private bool showTitle = true; // 最初にタイトル画像を表示するフラグ
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 最初にタイトル画像を表示
        titleImage.SetActive(true);
        howtoImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showTitle && Input.GetKeyDown(KeyCode.Space))
        {
            // タイトル画像を非表示にし、操作説明画像を表示
            titleImage.SetActive(false);
            howtoImage.SetActive(true);
            showTitle = false; // タイトル画像はもう一度表示しない
            count++;
        }
        if(count == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleNotes");
        }
    }
}