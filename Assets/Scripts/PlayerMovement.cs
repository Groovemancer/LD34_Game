using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 1f;

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
    private float jumpTimer = 0f;

	// Use this for initialization
	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update()
    { 

        if (jumpTimer > 0)
        {
            rigidBody.position = Vector2.Lerp(jumpStart, jumpEnd, (Time.time - jumpStartTime) / jumpDuration);
            jumpTimer -= Time.deltaTime;
        }
        if (jumpTimer <= 0f)
        {
            if (Input.GetButton("Right"))
            {
                jumpTimer = jumpDuration + jumpDelay;
                jumpStart = rigidBody.position;
                jumpEnd = jumpStart + new Vector2(1, 0);
                jumpStartTime = Time.time;
            }
            else if (Input.GetButton("Left"))
            {
                jumpTimer = jumpDuration + jumpDelay;
                jumpStart = rigidBody.position;
                jumpEnd = jumpStart + new Vector2(-1, 0);
                jumpStartTime = Time.time;
            }
        }
        //rigidBody.velocity = new Vector2(dir * speed, 0);
        
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
}
