using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Rigidbody2D rb;

    private float width;

    private float speed = -1f;

    
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.y;
        rb.velocity = new Vector2(0, speed);
    }

   
    void Update()
    {
        if (transform.position.y < -width)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        Vector2 vector = new Vector2(0, width * 2f);
        transform.position = (Vector2)transform.position + vector;
    }
}
