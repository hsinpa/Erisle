using UnityEngine;
using System.Collections;

public class cameracherge : MonoBehaviour {
	public float Smooth;
	public float Smooth1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMove.SightSwitch == true) {
			GameObject.Find ("Main Camera").transform.position = Vector3.Lerp (GameObject.Find ("Main Camera").transform.position, transform.position, Smooth * Time.deltaTime);

			GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, transform.rotation, Smooth * Time.deltaTime);
		}
		}

}
