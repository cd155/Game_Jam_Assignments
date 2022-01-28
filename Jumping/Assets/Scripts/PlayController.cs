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
    float originalX = 0.0f;

    [SerializeField] LayerMask platformLayerMask;
    // bool leftInput;
    // bool rightInput;
    bool jumpShort;
    bool jumpMiddle;
    bool jumpLarge;
    private float time = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalX = rigidbody2D.position.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (jumpShort && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(0, jumpSpeedShort);
        }
        else if (jumpMiddle && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(0, jumpSpeedMiddle);
        }
        else if (jumpLarge && isGrounded())
        {
            rigidbody2D.velocity = new Vector2(0, jumpSpeedLarge);
        }
        else if (isGrounded())
        {
            rigidbody2D.MovePosition(new Vector2(originalX, rigidbody2D.position.y));
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

    private bool isGrounded()
    {
        Collider2D groundCollider = Physics2D.OverlapBox(rigidbody2D.position + Vector2.down*0.6f, new Vector2(0.6f,0.6f), 0.0f, platformLayerMask);
        return groundCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(rigidbody2D.position + Vector2.down * 0.5f, new Vector2(0.6f, 0.6f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Tilemap")
            Debug.Log(collision.gameObject.name);
        // condition to destory object
        switch (collision.gameObject.name)
        {
            case "Tilemap":
                break;
    
            default:
                List<GameObject> targetList = GameObject.Find("Score Board").GetComponent<ScoreBoard>().targetList;

                if(targetList.Count > 0 && targetList[0].name == collision.gameObject.name)
                {
                    Destroy(targetList[0], time);
                    targetList.RemoveAt(0);
                }

                if(targetList.Count == 0)
                {
                    Debug.Log("You Won");
                }
                Destroy(collision.gameObject, 1);
                break;
        }
    }
}
