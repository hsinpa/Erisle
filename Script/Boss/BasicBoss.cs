using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
public class BasicBoss : MoveClass {
	public enum BossState {Idle, Move, Stun, Block, Attack};
	public BossState state = BossState.Idle;
	public float hp = 1000;
	public SkillState currentState;
	public int maxWalkVelocity = 1;
	public int maxAttackVelocity = 2;
	public float spawnRange = 15;
	public int searchRadius = 10;
	public int loseVisionRange = 15;
	public int playerLayer = 1 << 10;
	public int terrainLayer = 1 << 8;
	public Transform target;
	public Transform basePos;
	public Vector3 centerPoint;
	public List<AttackSet> attackSets = new List<AttackSet>();
	protected DemageBehavior damagebehavior;

	public void Start() {
		centerPoint = transform.position;
		damagebehavior = new DemageBehavior(this);
	}
	
	public void FixedUpdate () {
		calculateGrivaty();
	}
	
	public void changeState(SkillState newState) {
		currentState.exit();
		currentState = newState;
		newState.enter(this);
	}

	public virtual void beDamaged(JSONObject json) {
			damagebehavior.demaged(json);
	}
	
	}
}
