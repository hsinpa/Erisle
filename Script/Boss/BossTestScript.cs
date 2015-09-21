using UnityEngine;
using System.Collections;
using Boss;

public class BossTestScript : MonoBehaviour {
	//Only for Testing purposes

	private BasicBoss boss;
	private JSONObject testJson;
	// Use this for initialization
	void Start () {
		boss = GetComponent<BasicBoss>();
		JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField("demage", 10);
		//string
		jsonObject.AddField("type", "melee");
		//array
		JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
		jsonObject.AddField("effectList", arr);
		testJson = jsonObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			boss.beDamaged(testJson);
		}
	}

}
