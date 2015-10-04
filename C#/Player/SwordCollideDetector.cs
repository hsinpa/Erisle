using UnityEngine;
using System.Collections;

public class SwordCollideDetector : MonoBehaviour {
	private JSONObject damageData;
	public Input_Handler inputHandler;
	public int damage = 20;
	public bool goAttack = false;
	public Animator playercameraAni;
	public GameObject swordMark;
	public GameObject sworddie;
	public GameObject Markhere;
	//public GameObject here1;
	public GameObject database1;
	// Use this for initialization
	public SwordCollideDetector (fps level){

	}

	void Start () {
		TextAsset bindata= Resources.Load("JSON/damageData") as TextAsset;
		damageData = new JSONObject(bindata.ToString());

		inputHandler = transform.root.GetComponent<Input_Handler>(); 
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Monster" && inputHandler.Attack_Num > 0) {
			if(fps.swordenter == true){
			int attackNum = (inputHandler.Attack_Num > 3) ? 3 : inputHandler.Attack_Num;
			MonsterUnit unit = other.GetComponent<MonsterUnit>();

				//creating the effect
			Vector3 MonsterPosition = other.gameObject.transform.position;
			Vector3 PlayerPosition = gameObject.transform.position;
			Instantiate(database1, (MonsterPosition+PlayerPosition)/2, other.gameObject.transform.rotation); 
		
			GameObject SM =	Instantiate(swordMark, fps.heresST[fps.attacklevel].transform.position, fps.heresST[fps.attacklevel].transform.rotation) as GameObject;

			print(fps.heresST[fps.attacklevel]);
			GameObject.Find ("Main Camera").GetComponent<MotionBlur>().enabled = true ;  //啟動模糊


		 float percentage = damageData.GetField("Player").GetField(attackNum.ToString()).n / 100;
			unit.underAttack(Mathf.Abs(damage * percentage), attackNum);
			inputHandler.anim.speed= 0.7f;
			}
		}
		if (other.tag == "Boss") {
			Boss.BasicBoss unit = other.GetComponent<Boss.BasicBoss>();
			JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
			jsonObject.AddField("demage", 10);
			//string
			jsonObject.AddField("type", "melee");
			//array
			JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
			jsonObject.AddField("effectList", arr);
			unit.beDamaged(jsonObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Monster") {
			inputHandler.anim.speed= 1f;
			fps.swordenter = false;
		}
	}




}
