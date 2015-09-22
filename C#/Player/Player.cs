using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public float hp = 100;
	public float armor = 100;
	public enum State {Idle, Attack};

	protected int maxArmor = 100;

	void Start() {
		InvokeRepeating("resumeArmor", 2, 1.5f);

	}

	void resumeArmor() {
		if (armor < maxArmor) {
			armor++;
		}
	}

	public void underAttack(float damage) {
		if (armor > 0) {
			armor -= damage;
		} else {
			hp -= damage;
		}
	}


	//Update Version
	public void underBossAttack(JSONObject attackData) {
		float damage = attackData.GetField("damage").n;
		string effect = attackData.GetField("effect").str;

		if (armor > 0) {
			armor -= damage;
		} else {
			hp -= damage;
		}
		effectAttacher(effect);
	}

	
	private void effectAttacher(string effect) {
		switch (effect) {
		case "fly" :
			break;
		case "stun" :
			break;
		case "push" :
			break;
		default :
			break;
		}
	}

	private void flyEffect() {

	}

	private void pushEffect() {

	}

}
