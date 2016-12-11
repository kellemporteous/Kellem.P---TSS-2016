using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{

    GameManager gameManager;
    SoundController soundManager;

    //varibles that set the platers movement speend and position
    public float moveSpeed = 10.0f;
    public float maxHealth = 100.0f;
    public float health;

    private Transform myTransform;
    private Vector3 playerPosition;
    public GameObject[] muzzles;


    //variables for basic weapon
    public GameObject laser;
    public float laserFireRate = 0.2f;
    private float laserFireTime;

    public AudioClip laserSound;


    // Use this for initialization
    void Start()
    {
        myTransform = this.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundController>();

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = myTransform.position;

        Movement();
        BoundaryCheck();
        AimingSystem();
        FireLasers();

        myTransform.position = playerPosition;
    }

    public void AimingSystem()
    {
        Vector3 TargetDirection = Input.mousePosition;
        TargetDirection.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        TargetDirection = Camera.main.ScreenToWorldPoint(TargetDirection);
        transform.LookAt(TargetDirection);
    }


    private void FireLasers()
    {
        if (Input.GetMouseButton(0) && Time.time > laserFireTime)
        {
            for (int index = 0; index < muzzles.Length; ++index)
            {
                Instantiate(laser, muzzles[index].transform.position, muzzles[index].transform.rotation);
            }
            laserFireTime = Time.time + laserFireRate;
            soundManager.PlaySound(laserSound);
        }
    }

    public void BoundaryCheck()
    {
        if (playerPosition.x <= -gameManager.xBoundary)
        {
            playerPosition.x = -gameManager.xBoundary;
        }
        else if (playerPosition.x >= gameManager.xBoundary)
        {
            playerPosition.x = gameManager.xBoundary;
        }

        if (playerPosition.z <= -gameManager.zBoundary)
        {
            playerPosition.z = -gameManager.zBoundary;
        }
        else if (playerPosition.z >= gameManager.zBoundary)
        {
            playerPosition.z = gameManager.zBoundary;
        }

    }

    public void Movement()
    {
        //Move player to the left
        if (Input.GetKey("a"))
        {
            playerPosition.x = playerPosition.x - moveSpeed * Time.deltaTime;
        }
        //Move player to the right
        else if (Input.GetKey("d"))
        {
            playerPosition.x = playerPosition.x + moveSpeed * Time.deltaTime;
        }

        //Move player to the down
        if (Input.GetKey("s"))
        {
            playerPosition.z = playerPosition.z - moveSpeed * Time.deltaTime;
        }
        //Move player to the up
        else if (Input.GetKey("w"))
        {
            playerPosition.z = playerPosition.z + moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {

        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
