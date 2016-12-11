using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemy;
    public float spawnTime;
    public Transform[] spawnPosition;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Spawn()
    {
        int spawnPositionIndex = Random.Range (0, spawnPosition.Length);
        int enemyTypeIndex = Random.Range(0, enemy.Length);

        Instantiate(enemy[enemyTypeIndex] as GameObject, spawnPosition[spawnPositionIndex].position, spawnPosition[spawnPositionIndex].rotation);
    }
}
