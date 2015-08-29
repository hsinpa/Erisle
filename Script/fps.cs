using UnityEngine;
using System.Collections;

public class fps : MonoBehaviour {
	static public bool swordenter = false ;

	static public GameObject playerspineA;
	public GameObject playerspine;

	static public Camera playercamera;
    public Camera playercamera1;

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

		//GameObject.Find ("Main Camera").GetComponent<MotionBlur> ().enabled = false;
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

}


