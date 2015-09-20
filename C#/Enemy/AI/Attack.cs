using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnemyFSM {
	public class Attack : MonoBehaviour, State {
		private MonsterUnit self;
		private Rigidbody selfRigidbody;
		private Transform target;
		private int collisionCtrl = 1;
		private int maxSeeAhead = 1;
		private int wallLayer = 1 << 8;
		private float attackPeriod = 0;

		delegate bool CheckAttackDelegate(float distance, float hp, Animator anim, Transform transform);
		CheckAttackDelegate checkAttackDelegate;

		public void enter (MonsterUnit enemy) {
			self = enemy;
			target = GameObject.FindGameObjectWithTag("Player").transform;
			selfRigidbody = self.GetComponent<Rigidbody>();
			attackHandler(self.centerPoint.spawnMonsterType.name);
		}
		
		public void execute () {
			//steer += collisionAvoid();
			//selfRigidbody.velocity = steer;
			transform.LookAt(target);
			pursue();

		}
		
		public void exit () {
			Destroy(this);
		}

		
		private Vector3 collisionAvoid() {
			Vector3 mostThreatening = findMostThreateningObstacle();
			Vector3 avoidance = Vector3.zero;
			
			if (mostThreatening != Vector3.zero) {
				avoidance.x = self.transform.position.x- mostThreatening.x;
				avoidance.z = self.transform.position.z - mostThreatening.z;
				
				avoidance = Vector3.Normalize(avoidance);
				avoidance.Scale(new Vector3(10, 1, 5));
			}
			return avoidance;
		}
		
		private Vector3 findMostThreateningObstacle() {
			RaycastHit hitInfo;
			if (Physics.Linecast(self.transform.position, target.position, out hitInfo, wallLayer)) {
				if (Vector3.Distance(self.transform.position, hitInfo.point)< 2)
					return hitInfo.transform.position;
			}
			return Vector3.zero;
		}
		

		private void pursue() {
			Vector3 desired_velocity = target.position - self.transform.position;
			float distance = Vector3.Distance(target.position, self.transform.position);
			float centerDistance = Vector3.Distance(self.centerPoint.transform.position, self.transform.position);

			if (checkAttackDelegate(distance, self.hp, self.anim, transform)) {
				desired_velocity = Vector3.zero;
				float addtime = (self.anim.GetCurrentAnimatorStateInfo(0).length < 1) ? self.anim.GetCurrentAnimatorStateInfo(0).length : 1;
				attackPeriod = Time.time + addtime;
				//When outside territory range, back to search mode
			} else if (centerDistance >= self.centerPoint.territoryRange && distance > 6) {
				self.changeState(gameObject.AddComponent<EnemyFSM.Search>());
			} else {
				if (Time.time > attackPeriod) {
					self.m_CharCtrl.Move((transform.forward * self.maxAttackVelocity * Time.deltaTime) + new Vector3(0,self.MoveDir.y,0));
				}
				self.anim.SetBool("Attack", false);
			}
			
			self.anim.SetFloat("Speed", desired_velocity.magnitude);

		}


//		private Vector3 pursue() {
//			Vector3 desired_velocity = target.position - self.transform.position;
//			float distance = Vector3.Distance(target.position, self.transform.position);
//			float centerDistance = Vector3.Distance(self.centerPoint.transform.position, self.transform.position);
//			desired_velocity = Vector3.Normalize(desired_velocity) * self.maxAttackVelocity - selfRigidbody.velocity;
//
//			if (checkAttackDelegate(distance, self.hp, self.anim, transform)) {
//				desired_velocity = Vector3.zero;
//				float addtime = (self.anim.GetCurrentAnimatorStateInfo(0).length < 1) ? self.anim.GetCurrentAnimatorStateInfo(0).length : 1;
//				attackPeriod = Time.time + addtime;
//
//			//When outside territory range, back to search mode
//			} else if (centerDistance >= self.centerPoint.territoryRange && distance > 6) {
//						self.changeState(gameObject.AddComponent<EnemyFSM.Search>());
//			} else {
//				if (Time.time > attackPeriod) {
//					transform.Translate(Vector3.forward * self.maxAttackVelocity * Time.deltaTime);
//				}
//				self.anim.SetBool("Attack", false);
//			}
//
//			self.anim.SetFloat("Speed", desired_velocity.magnitude);
//			return desired_velocity;
//		}

		//Check if attack is available
		private void attackHandler(string type) {
			Debug.Log(type);

			switch (type) {
			case "Monkey":
				EnemyFSM.AttackMode.Both both = new EnemyFSM.AttackMode.Both();
				//both.mParticleEffect = gameObject.GetComponentsInChildren<ParticleSystem>();
				checkAttackDelegate = both.checkCanAttack;
				break;
			case "Triangle":
				EnemyFSM.AttackMode.TriangleHead triangle = new EnemyFSM.AttackMode.TriangleHead();
				checkAttackDelegate = triangle.checkCanAttack;
				break;

			default :
				checkAttackDelegate = new EnemyFSM.AttackMode.Melee().checkCanAttack;
				break;
			} 
		}

	}
}