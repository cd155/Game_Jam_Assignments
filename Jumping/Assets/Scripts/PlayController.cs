using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{   
    float speed = 5.0f;
    Rigidbody2D rigidbody2D;
    float jumpSpeedShort = 6.5f;
    float jumpSpeedMiddle = 9.0f;
    float jumpSpeedLarge = 10.5f;
    float originalX = 0.0f;
    float originalY = 0.0f;

    [SerializeField] LayerMask platformLayerMask;
    // bool leftInput;
    // bool rightInput;
    bool jumpShort;
    bool jumpMiddle;
    bool jumpLarge;
    private float time = 2.0f;
    public int chance = 3;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalX = rigidbody2D.position.x;
        originalY = rigidbody2D.position.y;
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
        Collider2D groundCollider = Physics2D.OverlapBox
        (
            rigidbody2D.position + Vector2.down * 0.15f, 
            new Vector2(1.2f,1.2f), 
            0.0f, 
            platformLayerMask
        );
        return groundCollider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(rigidbody2D.position + Vector2.down * 0.15f, new Vector2(1.2f, 1.2f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // condition to destory object
        switch (collision.gameObject.name)
        {
            case "Tilemap":
                break;

            case "rocket(Clone)":
                Destroy(collision.gameObject, 0);
                chance -= 1;
                List<GameObject> chanceIndicator = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>().chanceIndicator;
                Destroy(chanceIndicator[0], 0);
                chanceIndicator.RemoveAt(0);

                if(chance == 0)
                {
                    FindObjectOfType<GameManager>().EndGame();
                }
                break;

            default:
                List<GameObject> targetList = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>().targetList;

                if(targetList.Count > 0 && targetList[0].name == collision.gameObject.name)
                {
                    Destroy(targetList[0], 0);
                    targetList.RemoveAt(0);
                }

                if(targetList.Count == 0)
                {
                    FindObjectOfType<GameManager>().Winning();
                }

                Destroy(collision.gameObject, time);
                break;
        }
    }
    
    private void OnBecameInvisible()
    {   
        //fall out from the ground
        if(rigidbody2D.position.x < -3.0f || rigidbody2D.position.y < 0.0f)
        {
            chance -= 1;
            List<GameObject> chanceIndicator = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>().chanceIndicator;
            Destroy(chanceIndicator[0], 0);
            chanceIndicator.RemoveAt(0);

            if(chance == 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
        transform.position = new Vector3(originalX, originalY);
    }
}
