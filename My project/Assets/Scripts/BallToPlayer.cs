using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToPlayer : MonoBehaviour
{
    //プレイヤーオブジェクト
    public GameObject player;
    //弾のプレハブオブジェクト
    public GameObject tama;
    public GameObject[] Tama = new GameObject[9];

    //3秒ごとに弾を発射するためのもの
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

        //3秒経つごとに弾を発射する
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
            //敵の座標を変数posに保存
            var pos = Bullet[bullet/*[i]*/].transform.position;
        //弾のプレハブを作成
        var t = Instantiate(Tama[bullet/*[i]*/]);// as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector3 vec = player.transform.position - pos;
            //弾のRigidBodyコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody>().velocity = vec.normalized * speed;
        //}
    }
}
