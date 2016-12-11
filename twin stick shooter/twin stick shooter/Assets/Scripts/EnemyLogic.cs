using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

    public GameManager gameManager;

    //Movement variables
    public float moveSpeed;
    public float rotationSpeed;
    private float adjRotSpeed;
    private Quaternion targetRotation;

    public GameObject player;
    public float health;
    public float damage;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    private void Movement()
    {
        //Rotating towards the player based on LOS
        if (player.transform.position.z <= transform.position.z)
        {
            targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            adjRotSpeed = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, adjRotSpeed);
        }

        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //Enemy positional check vs boundary
        if (transform.position.z <= gameManager.zBoundary - 100)
            Destroy(this.gameObject);

    }

    void OnCollisionEnter(Collision otherObject)
    {

        if (otherObject.transform.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            otherObject.transform.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
