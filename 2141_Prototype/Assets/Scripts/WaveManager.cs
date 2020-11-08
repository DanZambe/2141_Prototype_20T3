using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public bool eyeEnemyWave1 = true;
    public bool stealthBomberWave1 = false;
    public bool electricEnemyWave1 = false;
    public bool playerMirrorWave1 = false;
    public bool boss = false;

	public int eyeEnemies;
	public int stealthBombers;
	public int electricEnemies;
	public int playerMirror;
	public int bossdead;

	public GameObject eyeEnemy1;
	public GameObject eyeEnemy2;
	public GameObject eyeEnemy3;
	public GameObject eyeEnemy4;
	public GameObject eyeEnemy5;
	public GameObject eyeEnemy6;

	public GameObject stealthBomber1;
	public GameObject stealthBomber2;
	public GameObject stealthBomber3;

	public GameObject electricEnemy1;
	public GameObject electricEnemy2;
	public GameObject electricEnemy3;
	public GameObject electricEnemy4;

	public GameObject playerMirrorOBJ;

	public GameObject bossOBJ;

	//IEnumerator coroutineTest;

	// Start is called before the first frame update
	void Start()
    {
		waveCheck();
		//coroutineTest = stealthBomberWave();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void waveCheck()
	{
		if (eyeEnemyWave1 == true)
		{
			eyeEnemy1.SetActive(true);
			eyeEnemy2.SetActive(true);
			eyeEnemy3.SetActive(true);
			eyeEnemy4.SetActive(true);
			eyeEnemy5.SetActive(true);
			eyeEnemy6.SetActive(true);
		}
		else if (electricEnemyWave1 == true)
		{
			electricEnemy1.SetActive(true);
			electricEnemy2.SetActive(true);
			electricEnemy3.SetActive(true);
			electricEnemy4.SetActive(true);
		}
		else if (playerMirrorWave1 == true)
		{
			playerMirrorOBJ.SetActive(true);
		}
		else if (boss == true)
		{
			bossOBJ.SetActive(true);
		}
		else if (stealthBomberWave1 == true)
		{
			stealthBomber1.SetActive(true);
			stealthBomber2.SetActive(true);
			stealthBomber3.SetActive(true);
			//StartCoroutine(coroutineTest);
			//StopCoroutine(coroutineTest);
		}
	}
	public void nextWave()
	{
		if (eyeEnemies >= 6)
		{
			eyeEnemyWave1 = false;
			electricEnemyWave1 = true;
			waveCheck();
			eyeEnemies = 0;
		}
		else if (electricEnemies >= 4)
		{
			electricEnemyWave1 = false;
			playerMirrorWave1 = true;
			waveCheck();
			electricEnemies = 0;

		}
		else if (playerMirror >= 1)
		{
			playerMirrorWave1 = false;
			boss = true;
			waveCheck();
			playerMirror = 0;

		}
		else if (bossdead >= 1)
		{
			boss = false;
			stealthBomberWave1 = true;
			waveCheck();
		}
	}
	//IEnumerator stealthBomberWave()
	//{
	//		yield return new WaitForSeconds(10);
	//		stealthBomberWave1 = false;
	//		electricEnemyWave1 = true;
	//		waveCheck();
	//}
}
