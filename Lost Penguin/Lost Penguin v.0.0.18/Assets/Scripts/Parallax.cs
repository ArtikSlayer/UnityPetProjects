﻿using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smoothing;

	private Transform cam;
	private Vector3 previosCamPos;


	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;

		previosCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) 
		{
			parallaxScales[i] = backgrounds[i].position.z *-1;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {

		for (int i = 0; i < backgrounds.Length; i++) 
		{
			float parallax = (previosCamPos.x - cam.position.x) * parallaxScales[i];

			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX,backgrounds[i].position.y,backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos,smoothing * Time.deltaTime);
		}

		previosCamPos = cam.position;
	}
}
