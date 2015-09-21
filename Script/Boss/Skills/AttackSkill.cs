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

			float distance = Vector3.Distance(self.target.position, self.transform.position);
			
			if ( distance > 5 ) {
				self.m_Ani.SetTrigger("Range");
				return;
			}

			string attackMethod = attackBehavior.getAttackAnimate( self.attackSets );
			self.m_Ani.SetTrigger(attackMethod);
		}
		
		public void exit ()	{
			Destroy(this);
		}
		
		#endregion

	}
}