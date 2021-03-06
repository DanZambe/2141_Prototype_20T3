﻿using System.Collections;
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
        Vector3 vector = new Vector3(0, width * 2f,1);
        transform.position = (Vector3)transform.position + vector;
    }
}
