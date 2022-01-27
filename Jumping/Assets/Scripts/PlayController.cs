using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{   
    float speed = 5.0f;
    Rigidbody2D rigidbody2D;
    float jumpSpeedShort = 25.0f;
    float jumpSpeedMiddle = 35.0f;
    float jumpSpeedLarge = 45.0f;

    [SerializeField] LayerMask platformLayerMask;
    // bool leftInput;
    // bool rightInput;
    bool jumpShort;
    bool jumpMiddle;
    bool jumpLarge;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (jumpShort && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeedShort);
        }
        else if (jumpMiddle && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeedMiddle);
        }
        else if (jumpLarge && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeedLarge);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }

    void Update()
    {
        // leftInput = Input.GetKey(KeyCode.LeftArrow);
        // rightInput = Input.GetKey(KeyCode.RightArrow);
        jumpShort = Input.GetKey(KeyCode.Z);
        jumpMiddle = Input.GetKey(KeyCode.X);
        jumpLarge = Input.GetKey(KeyCode.C);
    }

    bool isGrounded()
    {
        Collider2D groundCollider = Physics2D.OverlapBox(rigidbody2D.position + Vector2.down*0.6f, new Vector2(0.6f,0.6f), 0.0f, platformLayerMask);
        return groundCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(rigidbody2D.position + Vector2.down * 0.5f, new Vector2(0.6f, 0.6f));
    }
}
