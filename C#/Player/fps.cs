using UnityEngine;
using System.Collections;

public class fps : MonoBehaviour {
	static public bool swordenter = false ;

	static public GameObject playerspineA;
	public GameObject playerspine;

	static public Camera playercamera;
    public Camera playercamera1;

	public Transform Camerafollow;



	public Animator playerAni;
	public int fpsnum = 60;
	static public int attacklevel;
	public GameObject[] swordEffect;

	public GameObject[] heres;
	static public GameObject[] heresST;
	public GameObject[] swerdeffect ;
	
	private void Awake() {
		playerspineA = playerspine;
		playercamera = playercamera1;
		heresST = heres;
		playerAni = GetComponent<Animator>();
		Application.targetFrameRate = fpsnum; 

	}


	public void SwordaniEND (){

		GameObject.Find ("Main Camera").GetComponent<MotionBlur> ().enabled = false;
		swordenter = false;
		swerdeffect[0].SetActive (false);
		
	}
	public void Swordaniplaying(int attlv){
		attacklevel = attlv;
		swordenter = true;
		swerdeffect[0].SetActive (true);
	}
	public void  AttackEffect(int level){
		 
		GameObject effect =  Instantiate(swordEffect[level],heres[level].transform.position, heres[level].transform.rotation) as GameObject ; //creating the effect

		effect.transform.parent = heres[level].transform;
	}


	bool change ;
	public void Update(){

		if (Input.GetKeyDown ("space")) {
			if(change != true ){
			PlayerMove.SightSwitch= true;
			change = true ;
				playercamera1.GetComponent<MouseRotation>().enabled = false ;

				//playercamera1.transform.rotation=Vector3.Lerp(playercamera1.transform.rotation,Camerafollow.rotation,Smooth*Time.deltaTime);
			
				playercamera1.transform.parent = Camerafollow.transform;
			}else{
				PlayerMove.SightSwitch= false;
				change = false ;
				playercamera1.GetComponent<MouseRotation>().enabled = true ;

			}
		}
	
	
	}


}


