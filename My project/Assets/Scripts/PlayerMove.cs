using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPower;
    private bool isJumping = false;
    [SerializeField] private float Pspeed;
    private float speed;
    [SerializeField] float jumpCooldown;
    private bool canJump = true;

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
            speed = 2.5f;
        }
        else
        {
            speed = Pspeed;
        }

        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(1, 0, 0) * speed);
        }

        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && canJump)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
            canJump = false;
            StartCoroutine(JumpCooldown());
        }
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}