using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemyShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform leftGun;
    public Transform rightGun;
    public Transform topGun;
    public Transform bottomGun;

    public float shootTimer;

    public float rotationSpeed;
    // Start is called before the first frame update
    //void Start()
  //  {
  //
  //  }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
	public void FixedUpdate()
	{
        //shoot();

    }

    IEnumerator Start()
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
        Instantiate(bullet, topGun.position, topGun.rotation);
        Instantiate(bullet, bottomGun.position, bottomGun.rotation);

    }
}
