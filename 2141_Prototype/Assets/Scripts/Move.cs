using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY, moveSpeed;

    public GameObject bullet;
    public Transform leftGun;
    public Transform rightGun;

    public int health = 3;
    public int minHealth = 0;

    public int damage = 1;

    public bool isDead;
    public bool invincible;

    public string colliderTag;

    public int kills;

    public Text killsText;

    public Image lifeOne;
    public Image lifeTwo;
    public Image lifeThree;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
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
        yield return new WaitForSeconds(2);
        invincible = false;
    }

    public void Death()
    {
        if (health <= minHealth)
        {
            lifeThree.enabled = false;
            isDead = true;
            Destroy(gameObject);
        }

        if (health == 2)
		{
            lifeOne.enabled = false;
		}
		else if (health == 1)
		{
            lifeTwo.enabled = false;
        }

    }
}
