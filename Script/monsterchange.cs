using UnityEngine;
using System.Collections;

public class monsterchange : MonoBehaviour {
	public GameObject myCamera; // 紀錄要推倒的骨牌
	public int namber;
	public GameObject[] monster;

	// Use this for initialization

	void Awake () {
		myCamera.transform.position = monster[namber].transform.position;
	}


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)){
			myCamera.transform.position = monster[0].transform.position;
		} 
		
		if (Input.GetKeyDown(KeyCode.S)){
			myCamera.transform.position = monster[1].transform.position;
		} 
		
		if (Input.GetKeyDown(KeyCode.D)){
			myCamera.transform.position = monster[2].transform.position;
		} 
		
		if (Input.GetKeyDown(KeyCode.F)){
			myCamera.transform.position = monster[3].transform.position;
		} 
	}
}
