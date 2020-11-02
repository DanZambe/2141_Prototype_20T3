using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricEnemy : MonoBehaviour
{

    public string target;
    public Move playerRef;

    public Transform player;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;


    public GameObject mine;

    public float mineTimer;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(mineTimer);
            MakeMine();
        }
    }


    public void MakeMine()
    {
        Instantiate(mine, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, player.position);

        if (range > minDistance)
        {
            Debug.Log(range);

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == collision.tag)
        {
           // Debug.Log("collision detected");
            if (target == "PlayerTag")
            {
                collision.gameObject.GetComponent<Move>().TakeDamage();
            }
        }
    }
}
