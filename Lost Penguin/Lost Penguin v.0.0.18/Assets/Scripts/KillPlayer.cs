﻿using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManeger levelManeger;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		levelManeger = FindObjectOfType<LevelManeger> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Hero") {
			HealthManager.HurtPlayer(damageToGive);
			//levelManeger.RespawnPlayer();
		}
	}
}
