﻿using UnityEngine;
using System.Collections;

public class EnterEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		
		foreach (ContactPoint contact in collision.contacts) {
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			print(contact.point);
		}
		
		
	}
}
