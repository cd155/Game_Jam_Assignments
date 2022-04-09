using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

namespace RPGM.Gameplay
{
    /// <summary>
    /// A simple controller for animating a 4 directional sprite using Physics.
    /// </summary>
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public Vector3 nextMoveCommand;
        public Animator animator;
        public bool flipX = false;

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        PixelPerfectCamera pixelPerfectCamera;

        public GameObject ChickenPatrol1;
        public GameObject ChickenPatrol2;

        enum State
        {
            Idle, Moving
        }

        State state = State.Idle;
        Vector3 start, end;
        Vector2 currentVelocity;
        float startTime;
        float distance;
        float velocity;

        void IdleState()
        {
            if (nextMoveCommand != Vector3.zero)
            {
                start = transform.position;
                end = start + nextMoveCommand;
                distance = (end - start).magnitude;
                velocity = 0;
                UpdateAnimator(nextMoveCommand);
                nextMoveCommand = Vector3.zero;
                state = State.Moving;
            }
        }

        void MoveState()
        {
            velocity = Mathf.Clamp01(velocity + Time.deltaTime * acceleration);
            UpdateAnimator(nextMoveCommand);
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
            spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? true : false;
        }

        void UpdateAnimator(Vector3 direction)
        {
            if (animator)
            {
                animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
                animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
            }
        }

        void Update()
        {
            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Moving:
                    MoveState();
                    break;
            }
        }

        void LateUpdate()
        {
            if (pixelPerfectCamera != null)
            {
                transform.position = pixelPerfectCamera.RoundToPixel(transform.position);
            }
        }

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            pixelPerfectCamera = GameObject.FindObjectOfType<PixelPerfectCamera>();
        }

        // Customized Script

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // condition to move object
            switch (collision.gameObject.name)
            {
                case "Chicken1":
                    MoveObject(collision);
                    break;
                case "Chicken2":
                    MoveObject(collision);
                    break;
                case "Chicken3":
                    MoveObject(collision);
                    break;
                case "Chicken4":
                    MoveObject(collision);
                    break; 
                case "ChickenMove":
                    MoveObject(collision);
                    break;
                case "GoldenApple1":
                    MoveObject(collision);                    
                    break;
                case "GoldenApple2":
                    MoveObject(collision);                    
                    break;
                case "ChickenPatrol1":
                    var object1 = GameObject.Find("ChickenPatrol1");
                    var mypatro1 = object1.GetComponent<Patrol>();
                    mypatro1.dizzed = true;
                    Destroy(object1, 6.0f);
                    break; 
                case "ChickenPatrol2":
                    var object2 = GameObject.Find("ChickenPatrol2");
                    var mypatro2 = object2.GetComponent<Patrol>();
                    mypatro2.dizzed = true;
                    Destroy(object2, 6.0f);
                    break;                                                                                
                default:
                    break;
            }
        }

        private void MoveObject(Collision2D collision)
        {
            collision.transform.position = new Vector3(
                collision.transform.position.x + nextMoveCommand.x, 
                collision.transform.position.y + nextMoveCommand.y,
                0);
        }
    }
}