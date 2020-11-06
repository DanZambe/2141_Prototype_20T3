using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bigCenterBullet;
    public GameObject cannonBullet;
    public GameObject smallFastBullets;
    public GameObject laserBullet;



    public Transform leftLazer;
    public Transform rightLazer;
    public Transform leftCannon;
    public Transform rightCannon;
    public Transform rightLeftFast;
    public Transform rightRightFast;
    public Transform leftLeftFast;
    public Transform leftRightFast;
    public Transform bigCenter;

    public float lazerSpeed;
    public float cannonSpeed;
    public float fastBulletSpeed;
    public float fastBulletSpeed2;
    public float centerSpeed;

    public bool outsideShot;

    // Start is called before the first frame update
    void Start()
      {
        StartCoroutine(Lazers());
        StartCoroutine(Cannons());
        StartCoroutine(FastFiringInside());
        //StartCoroutine(FastFiringOutside());
        StartCoroutine(BigCenter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        //shoot();

    }

    IEnumerator Lazers()
    {
        while (true)
        {
            yield return new WaitForSeconds(lazerSpeed);
            ShootLazer();
        }
    }

    IEnumerator Cannons()
    {
        while (true)
        {
            yield return new WaitForSeconds(cannonSpeed);
            ShootCannon();
        }
    }
    IEnumerator FastFiringInside()
    {
        while (true)
        {
			if (outsideShot == true)
			{
                yield return new WaitForSeconds(fastBulletSpeed);
                ShootFastGunsInside();
                outsideShot = false;
            }
			else
			{
                yield return new WaitForSeconds(fastBulletSpeed2);
                ShootFastGunsOutside();
                outsideShot = true;
            }

        }
    }
    //IEnumerator FastFiringOutside()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(fastBulletSpeed2);
    //        ShootFastGunsOutside();
    //    }
    //}
    IEnumerator BigCenter()
    {
        while (true)
        {
            yield return new WaitForSeconds(centerSpeed);
            ShootCenter();
        }
    }




    public void ShootLazer()
    {
        Instantiate(laserBullet, leftLazer.position, leftLazer.rotation);
        Instantiate(laserBullet, rightLazer.position, rightLazer.rotation);
    }

    public void ShootCannon()
    {
        Instantiate(cannonBullet, leftCannon.position, leftCannon.rotation);
        Instantiate(cannonBullet, rightCannon.position, rightCannon.rotation);
    }
    public void ShootFastGunsInside()
    {
        Instantiate(smallFastBullets, rightLeftFast.position, rightLeftFast.rotation);
        Instantiate(smallFastBullets, leftRightFast.position, leftRightFast.rotation);
    }
    public void ShootFastGunsOutside()
    {
        Instantiate(smallFastBullets, rightRightFast.position, rightRightFast.rotation);
        Instantiate(smallFastBullets, leftLeftFast.position, leftLeftFast.rotation);
    }
    public void ShootCenter()
    {
        Instantiate(bigCenterBullet, bigCenter.position, bigCenter.rotation);
    }

}
