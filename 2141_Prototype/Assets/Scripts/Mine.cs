using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public string target;
    public GameObject playerGO;
    public Move playerRef;



    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindWithTag("PlayerTag");
        playerRef = playerGO.GetComponent<Move>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == collision.tag)
        {
            Debug.Log("collision detected");
            if (target == "PlayerTag")
            {
                collision.gameObject.GetComponent<Move>().TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}
