using UnityEngine;
using System.Collections;

public class Monkey : MonsterUnit {
	float hitBackPercentage = 10;
	int backwardStrenght = 10;

	void Start() {
		//Defualt Search
		base.Start();
		currentState = gameObject.AddComponent<EnemyFSM.Search>();
		currentState.enter(this);
		setCommonData();
	}

	protected void setCommonData() {
		base.setCommonData();
		rangeAttack = monsterCol.GetField("rangeAttack").n;
	}

	
	protected void FixedUpdate () {
		base.FixedUpdate();
		
	}

	public override void underAttack(float attackStrength, int attackNum) {

		if (attackNum != lastAttackNum) {
			hp -= attackStrength;
			if (Random.Range(0, 100) < hitBackPercentage) {
				selfRigidbody.AddForce(-transform.forward * backwardStrenght);
			}

			anim.SetTrigger("Beaten");

			if (hp <= 0 ) {
				changeState(gameObject.AddComponent<EnemyFSM.Dead>());
				anim.SetBool("Dead", true);
			}
			lastAttackNum = attackNum;
			StartCoroutine(resumeAttackNum(0.5f));
		}
	}

}
