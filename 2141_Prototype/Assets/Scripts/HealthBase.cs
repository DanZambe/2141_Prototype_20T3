using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase
{
    public int health;
    public int maxHealth;
    public bool isDead;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        // health = health - damage
        Death();
    }

    public void Death()
    {
        if (health<maxHealth)
        {
            isDead = true;
        }
    }
}
