using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove2 : MonoBehaviour
{
    float top;

    float bottom;

    float exchange = 0.03f;

    void Start()
    {
        top = gameObject.transform.position.x + 3f;
        bottom = gameObject.transform.position.x - 3f;
    }

    void Update()
    {
        if (gameObject.transform.position.x > top)
        {
            exchange = -0.03f;
        }

        if (gameObject.transform.position.x < bottom)
        {
            exchange = 0.03f;
        }

        gameObject.transform.Translate(exchange, 0, 0);
    }
}
