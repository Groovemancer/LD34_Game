using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D rigidBody;

    private SpriteRenderer spriteRenderer;

    public Sprite sprite1;
    public Sprite sprite2;
    private bool spriteChanged = false;

    private CircleCollider2D circCollider;

    private Vector2 jumpStart;
    private Vector2 jumpEnd;
    private float jumpStartTime;
    public float jumpDuration = 0.5f;
    public float jumpDelay = 0.1f;
    private float jumpDelayTimer = 0f;
    private float jumpTimer = 0f;
    private float jumpDir = 0f;

    private Vector2 directionalVector;
    private Vector2 desiredVelocity;
    private float lastSqrMag;
    private Animator anim;

	// Use this for initialization
	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
    { 

        if (jumpTimer > 0)
        {            
            jumpTimer -= Time.deltaTime;            
        }
        if (jumpDelayTimer > 0)
        {
            jumpDelayTimer -= Time.deltaTime;
            
        }
        if (jumpDelayTimer <= 0f)
        {
            jumpDir = 0;
            rigidBody.velocity = new Vector2();            
        }
        if (jumpTimer <= 0f)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                jumpTimer = jumpDuration + jumpDelay;
                jumpDelayTimer = jumpDelay;
                jumpStart = new Vector2(transform.position.x, transform.position.y);
                if (Input.GetAxis("Horizontal") < 0)
                    jumpDir = -1;
                else if (Input.GetAxis("Horizontal") > 0)
                    jumpDir = 1;

                jumpEnd = jumpStart + new Vector2(jumpDir, 0);
                directionalVector = (jumpEnd - jumpStart).normalized * speed;
                lastSqrMag = Mathf.Infinity;
                desiredVelocity = directionalVector;
                anim.SetTrigger("Jump");
            }
        }

        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        float sqrMag = (jumpEnd - currentPos).sqrMagnitude;

        if (sqrMag > lastSqrMag)
        {
            desiredVelocity = Vector2.zero;
        }
        lastSqrMag = sqrMag;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (!spriteChanged)
            {
                spriteRenderer.sprite = sprite2;
                circCollider.radius = 0.625f;
                spriteChanged = true;
            }
            else
            {
                spriteRenderer.sprite = sprite1;
                circCollider.radius = 0.5f;
                spriteChanged = false;                
            }
        }
	}

    void FixedUpdate()
    {
        rigidBody.velocity = desiredVelocity;
    }
}
