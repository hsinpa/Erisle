using UnityEngine;
using System.Collections;

public class monkydie : MonoBehaviour {
	public GameObject monkey1;
	public GameObject monkeyboon;
	public GameObject monkey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Monkeydie (){

		Instantiate(monkeyboon, monkey1.transform.position, monkey1.transform.rotation);
		Destroy(monkey);
		//Instantiate(monkey, gameObject.transform.position, gameObject.transform.rotation);

	}

}
