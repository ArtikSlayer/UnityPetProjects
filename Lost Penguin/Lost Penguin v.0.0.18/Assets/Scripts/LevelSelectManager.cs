﻿using UnityEngine;
using System.Collections;

public class LevelSelectManager : MonoBehaviour {

	public string[] levelTags;

	public GameObject[] locks;

	public bool[] levelUnlocked;

	public int positionSelector;

	public float distanceBelowLock;

	public string[] levelName;

	public float moveSpeed;

	private bool isPressed;



	void Start()
	{
		for(int i = 0; i < levelTags.Length; i++)
		{

			//if(PlayerPrefs.GetInt(levelTags[i]) == null)
			//{
				//levelUnlocked[i] = false;

			//}else
				if (PlayerPrefs.GetInt(levelTags[i]) == 0)
			{
				levelUnlocked[i] = false;

			}else{
				levelUnlocked[i] = true;
			}

			if(levelUnlocked[i])
			{
				locks[i].SetActive(false);
			}
		}
		transform.position = locks[positionSelector].transform.position + new Vector3 (0,distanceBelowLock,0);
	}

	void Update()
	{
		if (!isPressed)
		{
			if(Input.GetAxis("Horizontal") > 0.25f)
			{
				positionSelector += 1;
				isPressed = true;
				//transform.position.z=-1;
			}

			if(Input.GetAxis("Horizontal") < -0.25f)
			{
				positionSelector -= 1;
				isPressed = true;
				//transform.position.z=1;
			}

			if(positionSelector >= levelTags.Length)
			{
				positionSelector = levelTags.Length - 1;
			}

			if(positionSelector < 0)
			{
				positionSelector = 0;
			}
		}

		if (isPressed) 
		{
			if(Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
			{
				isPressed = false;
			}
		}

		transform.position = Vector3.MoveTowards (transform.position, locks [positionSelector].transform.position + new Vector3 (0, distanceBelowLock, 0), moveSpeed * Time.deltaTime);

		if (Input.GetButtonDown ("Jump")) 
		{
			if(levelUnlocked[positionSelector])
			{
				Application.LoadLevel(levelName[positionSelector]);
			}
		}
	}
}
