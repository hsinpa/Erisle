using UnityEngine;
using System.Collections;

public class fps : MonoBehaviour {
	static public bool swordenter = false ;

	static public GameObject playerspineA;
	public GameObject playerspine;

	public float DirectionDampTime = .25f;
	static public Camera playercamera;
    public Camera playercamera1;
	//模式變換攝影機位置
	static public GameObject CameraHear;

	public Transform Camerafollow;

	public Transform IKfollow;

	public Animator playerAni;
	public int fpsnum = 60;
	static public int attacklevel;
	public GameObject[] swordEffect;

	public GameObject[] heres;
	static public GameObject[] heresST;
	public GameObject[] swerdeffect ;
	public Animator GunAnim;

	bool change ;

	private void Awake() {
		playerspineA = playerspine;
		playercamera = playercamera1;
		heresST = heres;
		playerAni = GetComponent<Animator>();
		Application.targetFrameRate = fpsnum;
		//抓取紀錄物件
		CameraHear = GameObject.Find ("CameraHear"); 

	}


	public void Update(){
		
		GunChange ();
		
		
	}





	public void GunComponent(){

		gameObject.GetComponent<MouseLook1>().enabled =true ;
		gameObject.GetComponent<RootMotion.FinalIK.AimIK>().enabled =true ;
		gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled =true ;
		gameObject.GetComponent<GunFire>().enabled =true ;

	}



	public void SwordaniEND (){

		playercamera1.GetComponent<MotionBlur> ().enabled = false;
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

	public void GunChange(){

		if (Input.GetKeyDown ("space")) {
			if(change != true ){
				//模式變換攝影機位置記錄
				CameraHear.transform.position = playercamera1.transform.position;
				CameraHear.transform.rotation = playercamera1.transform.rotation;
				PlayerMove.SightSwitch= true;
				change = true ;
				playercamera1.GetComponent<MouseRotation>().enabled = false ;

				playerAni.SetBool("Run", false);
				
				
				playercamera1.transform.parent = Camerafollow.transform;
			}else{
				PlayerMove.SightSwitch= false;
				change = false ;

				gameObject.GetComponent<MouseLook1>().enabled =false ;
				gameObject.GetComponent<RootMotion.FinalIK.AimIK>().enabled =false ;
				gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled =false ;

			}
		}
		
		
	}

	public void Cameraback(){
		playercamera1.GetComponent<MouseRotation>().enabled = true ;
	} 


	public void GunModelChange(){

	float GunanimNub = GunAnim.GetFloat ("Gunchange");
		if(GunanimNub ==0  ){
		GunAnim.SetFloat ("Gunchange", 1);

		}else{
		GunAnim.SetFloat ("Gunchange", 0);
		}
	}



}


