using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour {
	
	public Transform bullet;
	public Texture Cross;//準心
	public Transform target;
	public Transform IKFollow;
	public float pokeForce;
	public float Smooth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*  if (Input.GetButtonDown("fire1"))
        {
             RaycastHit hit;
            if (Physics.Raycast(target.position, target.forward, hit))
            {
                IKFollow = hit.point;
            }

        }*/
		//if (Input.GetMouseButtonDown(0)){
		
		RaycastHit hit;
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (target.position, target.forward, out hit)) {

				if (hit.collider.tag != "Player"){
					IKFollow.transform.position = Vector3.Lerp (IKFollow.transform.position, hit.point, Smooth * Time.deltaTime);
				}

		}	
		//}
		
		
	}
}