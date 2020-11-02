using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int minHealth;

    public int damage;

    public bool isDead;

    public string colliderTag;

    public Move playerRef;

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

	// Update is called once per frame
	void Update()
	{

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
        health = health - damage;
        Death();
    }

    public void Death()
    {
        if (health <= minHealth)
        {
            isDead = true;
            Destroy(gameObject);
            playerRef.kills = playerRef.kills + 1;
        }
    }
}
