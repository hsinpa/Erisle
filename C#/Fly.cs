using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	public GameObject speed ;
	float  zSpeed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")){
			speed.transform.Translate(0,0,zSpeed*Time.deltaTime);
	    }
		if (Input.GetKey ("s")) {
			speed.transform.Translate(0,0,-zSpeed*Time.deltaTime);
		}

	}

}
