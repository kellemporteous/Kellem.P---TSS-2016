using UnityEngine;
using System.Collections;

public class PickUp_Spawner : MonoBehaviour
{
    public GameObject[] pickUps;
    public float spawnTime;
    public Vector3 spawnPosition;
    public float lifeTime;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnPickUp", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPickUp()
    {
        Vector3 spawnPositionIndex = new Vector3 (Random.Range(-spawnPosition.x, spawnPosition.x), 1, Random.Range(-spawnPosition.z, spawnPosition.z));
        int pickUpTypeIndex = Random.Range(0, pickUps.Length);

        Instantiate(pickUps[pickUpTypeIndex], spawnPositionIndex + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }
}