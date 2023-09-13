using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPower;
    public float DownPower;
    private bool isJumping = false; 
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    void Update()
    {
        if (isJumping)
        {
            speed = 1.3f;
        }
        else speed = 3.0f;
        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(1, 0, 0) * speed);
        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }



    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor"))
    //    {
    //        isJumping = false;
    //    }
    //}

}