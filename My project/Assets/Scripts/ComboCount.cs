using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject combocounter;
    [SerializeField] Text Currentcombo; // ���݂̃R���{����\������Text�R���|�[�l���g
    [SerializeField] Text Maxcombo; // �ő�R���{����\������Text�R���|�[�l���g

    private int combo = 0;
    private int maxCombo = 0;

    // OnTriggerEnter�̓g���K�[�R���W�����ɑ��̃R���C�_�[���N�������u�ԂɌĂяo����܂�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == combocounter)
        {
            // 'combocount'�ɓ��������ꍇ�A�R���{�����Z
            combo++;

            // �ő�R���{�����X�V
            if (combo > maxCombo)
            {
                maxCombo = combo;
            }

            // �R���{����Text�R���|�[�l���g�ɕ\��
            if (Currentcombo != null)
            {
                Currentcombo.text = "Combo: " + combo.ToString();
            }
        }
        else if (other.gameObject == player)
        {
            // 'player'�ɓ��������ꍇ�A�R���{�����Z�b�g
            combo = 0;

            // ���Z�b�g��̃R���{����Text�R���|�[�l���g�ɕ\��
            if (Currentcombo != null)
            {
                Currentcombo.text = "Combo: " + combo.ToString();
            }
        }

        // �ő�R���{����Text�R���|�[�l���g�ɕ\��
        if (Maxcombo != null)
        {
            Maxcombo.text = "Max Combo: " + maxCombo.ToString();
        }
    }

    // ���̃R�[�h����ő�R���{�����擾���邽�߂̃��\�b�h
    public int GetMaxCombo()
    {
        return maxCombo;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ������
        combo = 0;
        maxCombo = 0;

        // Text�R���|�[�l���g�ɏ����l��ݒ�
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
        // �����ɕK�v�ȏ�����ǉ�
    }
}