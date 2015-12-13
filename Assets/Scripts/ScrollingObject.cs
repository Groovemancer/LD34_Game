using UnityEngine;
using System.Collections;

public class ScrollingObject : MonoBehaviour
{
    public float scrollSpeed;

    private Rigidbody2D rigidBody;

    public Effect effect;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(0, scrollSpeed) * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            effect.ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "LevelEnd")
        {
            Destroy(gameObject);
        }
    }
}
