using UnityEngine;
using System.Collections;

public class cameracherge : MonoBehaviour {
	public float Smooth;


	// Use this for initialization



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMove.SightSwitch == true) {
			//紀錄位置

		//	Camerarotation = fps.playercamera.transform.rotation;
			//平滑移動角度及位置
			GameObject.Find ("Main Camera").transform.position = Vector3.Lerp (GameObject.Find ("Main Camera").transform.position, transform.position, Smooth * Time.deltaTime);
			GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, transform.rotation, Smooth * Time.deltaTime);
		}else{
			if(PlayerMove.SightSwitch == false) {
				//平滑移動角度及位置
				GameObject.Find ("Main Camera").transform.position = Vector3.Lerp (GameObject.Find ("Main Camera").transform.position, fps.CameraHear.transform.position, Smooth * Time.deltaTime);
				GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, fps.CameraHear.transform.rotation, Smooth * Time.deltaTime);
			}


		}
		}

}
