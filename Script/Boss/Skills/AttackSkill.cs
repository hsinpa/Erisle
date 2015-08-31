using UnityEngine;
using System.Collections;

namespace Boss {
	public class AttackSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private AttackBehavior attackBehavior;

		#region SkillState implementation
		
		public void execute () {
		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			attackBehavior = new AttackBehavior();
			self.transform.rotation = Quaternion.LookRotation(self.target.position);

			Debug.Log(attackBehavior.getAttackAnimate( self.attackSets ));
		}
		
		public void exit ()	{
			Destroy(this);
		}
		
		#endregion


		public void Fire() {
			Vector3 targetPosition = self.target.position;
			self.transform.rotation = Quaternion.LookRotation(new Vector3(targetPosition.x, self.transform.position.y,targetPosition.z ));
		}

		public void Hold() {
			
		}
	}
}