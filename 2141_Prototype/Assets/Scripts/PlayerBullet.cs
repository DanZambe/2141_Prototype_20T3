using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public string target;

    private Rigidbody2D rigidbody;
    public int speed = 300;

    public int myDamage;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(transform.up.x, transform.up.y);
        rigidbody.velocity = direction * Time.fixedDeltaTime * speed;
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == collision.tag)
		{
            Debug.Log("collision detected");
            if (target == "PlayerTag")
			{
                collision.gameObject.GetComponent<Move>().damage = myDamage;

                collision.gameObject.GetComponent<Move>().TakeDamage();
                Destroy(gameObject);
			}
			else if (target == "Enemy")
			{
                collision.gameObject.GetComponent<Enemy>().TakeDamage();
                Destroy(gameObject);
            }
		}
    }
}
