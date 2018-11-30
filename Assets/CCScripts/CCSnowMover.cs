using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCSnowMover : MonoBehaviour {

    public GameObject[] snowflakes;
    public Vector3 spawnValue;


    public int snowFlakeCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator SpawnSnowflakes()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < snowFlakeCount; i++)
            {
                GameObject snowflake = snowflakes[Random.Range(0, snowflakes.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(snowflake, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }

    }
}
