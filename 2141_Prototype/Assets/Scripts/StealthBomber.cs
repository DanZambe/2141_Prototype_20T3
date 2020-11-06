using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthBomber : MonoBehaviour
{

    public GameObject StealthBommberOBJ;
    public Transform Spawn1;
    public Transform Spawn2;
	public Transform Spawn3;
	public Transform Spawn4;
	public Transform Spawn5;
	public float shootTimer;

	public void Start()
	{
		StartCoroutine(Shooting());
	}

	IEnumerator Shooting()
	{
	    
	    
	        yield return new WaitForSeconds(shootTimer);
	       shoot();
	    
	}

	public void shoot()
    {
        Instantiate(StealthBommberOBJ, Spawn1.position, Spawn1.rotation);
		Instantiate(StealthBommberOBJ, Spawn2.position, Spawn2.rotation);
		Instantiate(StealthBommberOBJ, Spawn3.position, Spawn3.rotation);
		Instantiate(StealthBommberOBJ, Spawn4.position, Spawn4.rotation);
		Instantiate(StealthBommberOBJ, Spawn5.position, Spawn5.rotation);

	}
}
