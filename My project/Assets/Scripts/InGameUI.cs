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
        // �ŏ��̃e�L�X�g�\����ݒ�
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        // �^�C�}�[��0�ȉ��ɂȂ�Ȃ��悤�ɐ���
        if (Timer < 0)
        {
            SceneManager.LoadScene("result");
        }

        // �^�C�}�[�̃e�L�X�g���X�V
        UpdateTimerText();
    }

    // �^�C�}�[�̃e�L�X�g���X�V����֐�
    void UpdateTimerText()
    {
        // TimerText�Ɏc�莞�Ԃ�\��
        TimerText.text = Timer.ToString("F1"); // "F1" �͏����_�ȉ�1���܂ŕ\������t�H�[�}�b�g
    }
}