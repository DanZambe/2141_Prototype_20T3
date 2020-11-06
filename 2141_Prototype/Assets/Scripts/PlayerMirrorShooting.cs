using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMirrorShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform leftGun;
    public Transform rightGun;
    public float shootTimer;

    private Rigidbody2D rb;
	private float dirX, dirY, moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        StartCoroutine(Shooting());
    }

	public void Update()
	{
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
       // dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }


    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTimer);
            shoot();
        }
    }

    public void shoot()
    {
        Instantiate(bullet, rightGun.position, rightGun.rotation);
        Instantiate(bullet, leftGun.position, leftGun.rotation);

    }
}
