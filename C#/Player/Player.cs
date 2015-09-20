using UnityEngine;
using System.Collections;

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
}
