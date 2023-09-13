using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToPlayer : MonoBehaviour
{
    //�v���C���[�I�u�W�F�N�g
    public GameObject player;
    //�e�̃v���n�u�I�u�W�F�N�g
    public GameObject tama;
    public GameObject[] Tama = new GameObject[9];

    //3�b���Ƃɒe�𔭎˂��邽�߂̂���
    //private float targetTime = 4.0f;
    private float soundTime1 = 0.139f;
    private float soundTime2 = 0.7f;
    private float soundTime2_2 = 0f;
    private float count = 0.65f;
    private float bgmTime = 0;

    public float speed;

    public int/*[]*/ bullet;

    public GameObject[] Bullet = new GameObject[9];

    private void Start()
    {
        //Time.timeScale = Time.timeScale * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);

        //bgmTime += 0.000041f;

        bgmTime = Time.realtimeSinceStartup / 3;
        Debug.Log(bgmTime);
        
        //Debug.Log(Time.realtimeSinceStartup / 3);

        //3�b�o���Ƃɒe�𔭎˂���
        //soundTime1 += 0.00413f;
        //currentTime = Time.realtimeSinceStartup / 3;

        /*if(currentTime >= 0.8)
        {
            Debug.Log(currentTime);
        }*/
        
        
        if(bgmTime >= 3.3 && bgmTime < 29.4)
        {
            if (0.777f/*0.139f*/ <= soundTime1)
            {
                soundTime1 = 0.0f;
                //Debug.Log(currentTime);
                RandomBullet();
            }
            soundTime1 += 0.00413f;
        }


        
        if (bgmTime >= 6.6 && bgmTime < 29.4)
        {
            if (0.63f <= soundTime2)
            {
                soundTime2 = 0.0f;
                //Debug.Log(currentTime);
                RandomBullet();
            }
            soundTime2 += 0.004f;
        }


        /*if (targetTime < currentTime)
        {
            currentTime = 0;

            RandomBullet();
        */


        

    }

    private void RandomBullet()
    {
        //for (int i = 0; i < 2; i++)
        //{
            bullet/*[i]*/ = Random.Range(0, 9);
            //�G�̍��W��ϐ�pos�ɕۑ�
            var pos = Bullet[bullet/*[i]*/].transform.position;
        //�e�̃v���n�u���쐬
        var t = Instantiate(Tama[bullet/*[i]*/]);// as GameObject;
            //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
            t.transform.position = pos;
            //�G����v���C���[�Ɍ������x�N�g��������
            //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
            Vector3 vec = player.transform.position - pos;
            //�e��RigidBody�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
            t.GetComponent<Rigidbody>().velocity = vec.normalized * speed;
        //}
    }
}
