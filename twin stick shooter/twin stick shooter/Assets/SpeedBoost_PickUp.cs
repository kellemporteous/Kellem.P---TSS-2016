﻿using UnityEngine;
using System.Collections;

public class SpeedBoost_PickUp : MonoBehaviour {
    public float lifeTime;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
