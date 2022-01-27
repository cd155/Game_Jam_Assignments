using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool leftInput;
    bool rightInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("movingX", rigidbody2D.velocity.x != 0);
        if (leftInput) spriteRenderer.flipX = true;
        else if (rightInput) spriteRenderer.flipX = false;
    }
    // Update is called once per frame
    void Update()
    {
        leftInput = Input.GetKey(KeyCode.LeftArrow);
        rightInput = Input.GetKey(KeyCode.RightArrow);
    }
}
