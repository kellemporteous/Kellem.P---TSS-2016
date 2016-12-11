using UnityEngine;
using System.Collections;

public class Laser : Projectile{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }

    public override void Movement()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}