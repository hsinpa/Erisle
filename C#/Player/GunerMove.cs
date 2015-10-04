using UnityEngine;
using System.Collections;

public class GunerMove : MonoBehaviour {
	public Animator playerAni;
	public float DirectionDampTime = .25f;
	public float RunDampTime = .25f;

	// Use this for initialization
	void Start () {
		playerAni = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMove.SightSwitch == true) {
			playerAni.SetFloat ("RunDirection1", 4, DirectionDampTime, Time.deltaTime);

		} 
		if (PlayerMove.SightSwitch == false) {
			playerAni.SetFloat ("RunDirection1", 5, DirectionDampTime, Time.deltaTime);

		}
		if((PlayerMove.SightSwitch == true) ){
			if (Input.GetKey (KeyCode.W)) {
				playerAni.SetFloat ("RunDirection1", 1, RunDampTime, Time.deltaTime);
				playerAni.SetFloat ("RunX", 0, RunDampTime, Time.deltaTime);
				playerAni.SetFloat ("RunY", 1, RunDampTime, Time.deltaTime);
			} else {
				
				if (Input.GetKey (KeyCode.S)){
					playerAni.SetFloat ("RunDirection1", 1, RunDampTime, Time.deltaTime);
					playerAni.SetFloat ("RunX", 0, RunDampTime, Time.deltaTime);
					playerAni.SetFloat ("RunY", -1, RunDampTime, Time.deltaTime);
				} else {
					if (Input.GetKey (KeyCode.A)){
						playerAni.SetFloat ("RunDirection1", 1, RunDampTime, Time.deltaTime);
						playerAni.SetFloat ("RunX", -1, RunDampTime, Time.deltaTime);
						playerAni.SetFloat ("RunY", 0, RunDampTime, Time.deltaTime);
					} else {
						if (Input.GetKey (KeyCode.D)) {
							playerAni.SetFloat ("RunDirection1", 1, RunDampTime, Time.deltaTime);
							playerAni.SetFloat ("RunX", 1,RunDampTime, Time.deltaTime);
							playerAni.SetFloat ("RunY", 0, RunDampTime, Time.deltaTime);
						} else {
							playerAni.SetFloat ("RunDirection1", 4, RunDampTime, Time.deltaTime);
							playerAni.SetFloat ("RunX", 0, RunDampTime, Time.deltaTime);
							playerAni.SetFloat ("RunY", 0,RunDampTime, Time.deltaTime);
						}
					}
				}
			}
			
		}
	}
}
