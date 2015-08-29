using UnityEngine;
using System.Collections;

public class monkybullets : MonoBehaviour {
	public GameObject bulles;
	public GameObject firehere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Mbulles(int level1 ){
		GameObject bulle = Instantiate (bulles, firehere.transform.position, firehere.transform.rotation) as GameObject ;
		if (level1 == 1) {
			bulle.GetComponent<Rigidbody>().AddForce ((transform.forward + new Vector3 (0.8F, 0,0 )) * 1000); 
		}
		}


	}

