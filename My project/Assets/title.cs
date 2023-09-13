using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    [SerializeField] GameObject titleImage; // �^�C�g���摜���i�[����GameObject
    [SerializeField] GameObject howtoImage; // ��������摜���i�[����GameObject

    private bool showTitle = true; // �ŏ��Ƀ^�C�g���摜��\������t���O
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �ŏ��Ƀ^�C�g���摜��\��
        titleImage.SetActive(true);
        howtoImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showTitle && Input.GetKeyDown(KeyCode.Space))
        {
            // �^�C�g���摜���\���ɂ��A��������摜��\��
            titleImage.SetActive(false);
            howtoImage.SetActive(true);
            showTitle = false; // �^�C�g���摜�͂�����x�\�����Ȃ�
            count++;
        }
        if(count == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleNotes");
        }
    }
}