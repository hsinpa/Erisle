using UnityEngine;
using System.Collections;

namespace Boss {
	public class AnimEventCallback : MonoBehaviour {
		BasicBoss self;
		BossAttackCollider[] bossAttackColliders;

		// Use this for initialization
		void Start () {
			self = gameObject.GetComponent<BasicBoss>();
			bossAttackColliders = self.gameObject.GetComponentsInChildren<BossAttackCollider>();

		}

		public void Fire() {
			Debug.Log("Fire");
			self.state = BasicBoss.BossState.Attack;
			
			foreach(BossAttackCollider weapon in bossAttackColliders) {
				weapon.on = true;
			}
		}
		
		public void Hold() {
			Debug.Log("Hold");
			self.changeState(gameObject.AddComponent<TraceSkill>());
			foreach(BossAttackCollider weapon in bossAttackColliders) {
				weapon.on = false;
			}
		}

	}
}