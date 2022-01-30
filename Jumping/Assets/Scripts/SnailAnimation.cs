using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAnimation: MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool leftInput;
    bool rightInput;
    bool zInput;
    bool xInput;
    bool cInput;

    public bool isWin;
    public bool isLose;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("isJump", rigidbody2D.velocity.y != 0);
        animator.SetBool("isWin", isWin);
        animator.SetBool("isLose", isLose);

        if (leftInput) spriteRenderer.flipX = true;
        else if (rightInput) spriteRenderer.flipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        leftInput = Input.GetKey(KeyCode.LeftArrow);
        rightInput = Input.GetKey(KeyCode.RightArrow);
        zInput = Input.GetKey(KeyCode.Z);
        xInput = Input.GetKey(KeyCode.X);
        cInput = Input.GetKey(KeyCode.C);
    }
}
