using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public float hp = 100;
	public float armor = 100;
	public enum State {Idle, Attack, Disable};
	private Input_Handler inputHandler;
	protected int maxArmor = 100;

	void Start() {
		InvokeRepeating("resumeArmor", 2, 1.5f);
		inputHandler = gameObject.GetComponent<Input_Handler>();
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
		if (inputHandler.currentState != Player.State.Disable) {
			switch (effect) {
			case "fly" :
				flyEffect();
				break;
			case "stun" :
				break;
			case "push" :
				pushEffect();
				break;
			default :
				break;
			}
		}
	}

	public void Resume() {
		inputHandler.currentState = Player.State.Idle;
	}

	private void flyEffect() {
		inputHandler.anim.SetTrigger("Fly");
		inputHandler.currentState = Player.State.Disable;
	}

	private void pushEffect() {
		inputHandler.anim.SetTrigger("Fly");
		inputHandler.currentState = Player.State.Disable;
	}

}
