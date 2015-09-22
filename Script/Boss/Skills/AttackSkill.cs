using UnityEngine;
using System.Collections;

namespace Boss {
	public class AttackSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private AttackBehavior attackBehavior;
		BossAttackCollider[] bossAttackColliders;

		#region SkillState implementation
		
		public void execute () {

		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			attackBehavior = new AttackBehavior();
			bossAttackColliders = self.gameObject.GetComponentsInChildren<BossAttackCollider>();

			float distance = Vector3.Distance(self.target.position, self.transform.position);
			
			if ( distance > 5 ) {
				self.m_Ani.SetTrigger("Range");
				return;
			}

			string attackMethod = attackBehavior.getAttackAnimate( self.bossData );
			self.m_Ani.SetTrigger(attackMethod);
		}
		
		public void exit ()	{
			Destroy(this);
		}
		
		#endregion
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