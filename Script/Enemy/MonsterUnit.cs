using UnityEngine;
using System.Collections;

public class MonsterUnit : MoveClass {

	public State currentState;
	public float hp = 100;
	public float attack = 5;
	public float rangeAttack;

	public Vector3 lastPlayerPos;
	public int maxWalkVelocity = 3;
	public int maxAttackVelocity = 7;
	public int slowRadius = 8;
	public Rigidbody selfRigidbody;
	public SpawnPoint centerPoint;
	public Animator anim;
	
	protected int searchRadius = 6;
	protected int playerLayer = 1 << 10;

	protected int lastAttackNum = 0;
	protected JSONObject monsterCol;

	protected void Start() {
		//Defualt Search
		anim = gameObject.GetComponent<Animator>();
		selfRigidbody = gameObject.GetComponent<Rigidbody>();
		//centerPoint = transform.parent.GetComponent<SpawnPoint>();
	}

	protected void setCommonData() {
		Debug.Log(gameObject.name);
		monsterCol = centerPoint.monsterData.GetField(centerPoint.spawnMonsterType.name);
		hp = monsterCol.GetField("hp").n;
		attack = monsterCol.GetField("attack").n;
	}

	protected void FixedUpdate () {
		currentState.execute();
		if (m_UseGrivate)
		{
			Grivate();
		}
	}

	//重力計算
	public void Grivate()
	{
		if (!m_CharCtrl.isGrounded)
		{
			m_isGround = false;
			MoveDir.y -= m_Grivate * Time.deltaTime;
		}
		else
		{
			m_isGround = true;
		}
		//限制最大掉落速度 = 重力*2
		if (MoveDir.y <= -m_Grivate*2 && m_Grivate != 0)
		{
			MoveDir.y = -m_Grivate*2;
		}
	}

	
	//Being attack by player
	public virtual void underAttack(float attackStrength, int attackNum) {
		if (attackNum != lastAttackNum) {
			hp -= attackStrength;
			//anim.SetTrigger("Beaten");
			if (hp <= 0 ) {
				changeState(gameObject.AddComponent<EnemyFSM.Dead>());
				anim.SetBool("Dead", true);
			}
			lastAttackNum = attackNum;
			StartCoroutine(resumeAttackNum(0.5f));
		}
	}
		
	protected IEnumerator resumeAttackNum(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		lastAttackNum = 0;
	}

	//Find Player
	public void fieldInspection() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius, playerLayer);
		foreach (Collider collide in hitColliders) {
			checkVisibiltiy(collide.transform);
		}
	}

	protected virtual void checkVisibiltiy(Transform target) {
		changeState(gameObject.AddComponent<EnemyFSM.Attack>());
	}

	public void changeState(State newState) {
		currentState.exit();
		currentState = newState;
		newState.enter(this);
	}
}
