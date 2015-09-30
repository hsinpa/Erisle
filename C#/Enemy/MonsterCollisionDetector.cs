using UnityEngine;
using System.Collections;

public class MonsterCollisionDetector : MonoBehaviour {

	public bool attackMomment = false;
	private float attack;

	void Start() {
		attack = transform.root.GetComponent<MonsterUnit>().attack;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Player player = other.GetComponent<Player>();
			player.underAttack(attack);
		}
	}
}
