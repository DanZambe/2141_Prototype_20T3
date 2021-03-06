﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY, moveSpeed;

    public GameObject bullet;
    public Transform leftGun;
    public Transform rightGun;

    public SpriteRenderer spriteRenderer;

    public int health = 3;
    public int minHealth = 0;

    public int damage = 1;

    public int damageDealt;

    public bool isDead;
    public bool invincible;

    public string colliderTag;

    public int kills;

    public Text killsText;

    public Image lifeOne;
    public Image lifeTwo;
    public Image lifeThree;

    public GameObject player;
    public Transform startlocation;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeed = 2.5f;
        //Debug.Log(rightGun.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;

		killsText.text =  "Kills: " + kills.ToString();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }


    public void shoot()
	{
        Instantiate(bullet, rightGun.position, rightGun.rotation);
        Instantiate(bullet, leftGun.position, leftGun.rotation);

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colliderTag == collision.tag)
        {
            Death();
        }
    }

    public void TakeDamage()
    {
		if (!invincible)
		{
            health = health - damage;
            Death();
            StartCoroutine(Invulnerability());
        }

    }

    IEnumerator Invulnerability()
    {
        invincible = true;
        spriteRenderer.color = new Color(255f, 0f, 0f, 1f); // Set to opaque black
        gameObject.transform.position = new Vector3(0,-2,0);
        yield return new WaitForSeconds(2);
        spriteRenderer.color = new Color(255f, 255f, 255f, 1f); // Set to opaque black
        invincible = false;
    }

    public void Death()
    {
        if (health <= minHealth)
        {
            lifeThree.enabled = false;
            isDead = true;
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

        if (health == 3)
		{
            lifeOne.enabled = false;
		}
		else if (health == 2)
		{
            lifeTwo.enabled = false;
        }
        else if (health == 1)
        {
            lifeThree.enabled = false;
        }

    }
}
