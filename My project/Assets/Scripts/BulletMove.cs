using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float top;

    float bottom;

    float exchange = 0.03f;

    void Start()
    {
        top = gameObject.transform.position.y + 3f;
        bottom = gameObject.transform.position.y - 3f;
    }

    void Update()
    {
        if (gameObject.transform.position.y > top)
        {
            exchange = -0.03f;
        }

        if (gameObject.transform.position.y < bottom)
        {
            exchange = 0.03f;
        }

        gameObject.transform.Translate(0, exchange, 0);
    }
}
