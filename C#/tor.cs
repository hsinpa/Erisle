using UnityEngine;
using System.Collections;

public class tor : MonoBehaviour {
	public GameObject tornado;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Tornado(){
		GameObject effect =  Instantiate(tornado,gameObject.transform.position, gameObject.transform.rotation) as GameObject ; //creating the effect
		
		effect.transform.parent = gameObject.transform;
	}
}
