using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
public class BasicBoss : MoveClass {
	public float hp = 100;
	public Animator anim;
	public SkillState currentState;
	public int maxWalkVelocity = 3;
	public int maxAttackVelocity = 5;
	public int slowRadius = 8;
	public float spawnRange = 15;
	public int searchRadius = 6;
	public int loseVisionRange = 15;
	public int playerLayer = 1 << 10;
	public int terrainLayer = 1 << 8;
	public Transform target;
	public Vector3 centerPoint;
	public List<AttackSet> attackSets = new List<AttackSet>();

	public void Start() {
		anim = gameObject.GetComponent<Animator>();
		centerPoint = transform.position;
	}
	
	public void FixedUpdate () {
		calculateGrivaty();
	}
	
	public void changeState(SkillState newState) {
		currentState.exit();
		currentState = newState;
		newState.enter(this);
	}
		
	}
}
