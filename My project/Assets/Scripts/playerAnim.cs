using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class playerAnim : MonoBehaviour
{
    Animator animator;

    PlayerScript PlayerScript;
    private bool setgra = false;
    private bool canJump = true;
    [SerializeField] float jumpCooldown;

    public float span = 1f;
    private float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Idol");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            animator.SetTrigger("Jump");
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