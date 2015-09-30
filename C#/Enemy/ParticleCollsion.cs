using UnityEngine;
using System.Collections;

public class ParticleCollsion : MonoBehaviour {
	private float attackPeriod = 0;
	private float attackDamage;
	private Player player;
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void OnParticleCollision(GameObject other) {
		if (Time.time > attackPeriod) {
			attackDamage = transform.root.GetComponent<MonsterUnit>().rangeAttack;
			attackPeriod = Time.time + 2;
			player.underAttack(attackDamage);
		}
	}
}
