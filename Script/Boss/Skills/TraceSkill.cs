using UnityEngine;
using System.Collections;

namespace Boss {
	public class TraceSkill : MonoBehaviour, SkillState {
		private MoveBehavior moveBehavior;
		private BasicBoss self;
		
		#region SkillState implementation

		public void execute () {
			moveBehavior.waypoint = self.target.position;
			moveBehavior.execute();
			moveBehavior.checkOutOfVision();
			self.transform.LookAt(self.target);
		}

		public void enter (BasicBoss boss) {
			self = boss;
			moveBehavior = new MoveBehavior(boss,  self.maxAttackVelocity, delegate {
				self.changeState(gameObject.AddComponent<AttackSkill>());
			});
		}

		public void exit ()	{
			Destroy(this);
		}

		#endregion

	}
}