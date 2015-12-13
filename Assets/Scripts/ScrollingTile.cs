using UnityEngine;
using System.Collections;

public class ScrollingTile : MonoBehaviour
{
    public float scrollSpeed;

    private Rigidbody2D rigidBody;

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
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Collision(other.gameObject);
    }

    private void Collision(GameObject otherObj)
    {
        if (otherObj.tag == "LevelEnd")
        {
            Destroy(gameObject);
        }
    }
}
