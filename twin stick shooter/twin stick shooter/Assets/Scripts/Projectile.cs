using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float lifeTime = 3.0f;
    public float moveSpeed = 10.0f;
    public float damage = 25.0f;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    public virtual void Movement()
    {

    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Enemy")
        {
            otherObject.GetComponent<EnemyLogic>().TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }

}
