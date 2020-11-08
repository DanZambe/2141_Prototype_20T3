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
    public GameObject playerGO;

    public bool eyeEnemy;
    public bool electricEnemy;
    public bool playerMirror;
    public bool boss;
    public GameObject waveManagerGO;
    public WaveManager waveManagerRef;

    // Start is called before the first frame update
    void Start()
    {
        waveManagerGO = GameObject.FindWithTag("waveManager");
        waveManagerRef = waveManagerGO.GetComponent<WaveManager>();
        playerGO = GameObject.FindWithTag("PlayerTag");
        playerRef = playerGO.GetComponent<Move>();
    }

	// Update is called once per frame
	void Update()
	{

	}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (colliderTag == collision.tag)
    //    {
    //        Death();
    //    }
    //}

    public void TakeDamage()
    {
        health = health - damage;
        Death();
    }

    public void Death()
    {
        if (health <= minHealth)
        {
            if (eyeEnemy == true)
            {
				waveManagerRef.eyeEnemies = waveManagerRef.eyeEnemies + 1;
                waveManagerRef.nextWave();
                isDead = true;
                Destroy(gameObject);
                playerRef.kills = playerRef.kills + 1;
            }
            else if (electricEnemy == true)
            {
                waveManagerRef.electricEnemies = waveManagerRef.electricEnemies + 1;
                waveManagerRef.nextWave();
                isDead = true;
                Destroy(gameObject);
                playerRef.kills = playerRef.kills + 1;
            }
            else if (playerMirror == true)
            {
                waveManagerRef.playerMirror = waveManagerRef.playerMirror + 1;
                waveManagerRef.nextWave();
                isDead = true;
                Destroy(gameObject);
                playerRef.kills = playerRef.kills + 1;
            }
            else if (boss == true)
            {
                waveManagerRef.bossdead = waveManagerRef.bossdead + 1;
                waveManagerRef.nextWave();
                isDead = true;
                Destroy(gameObject);
                playerRef.kills = playerRef.kills + 1;
            }
            isDead = true;
            Destroy(gameObject);
            playerRef.kills = playerRef.kills + 1;
        }
    }
}
