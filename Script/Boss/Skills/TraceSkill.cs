using UnityEngine;
using System.Collections;

namespace Boss {
	public class TraceSkill : MonoBehaviour, SkillState {
		private MoveBehavior moveBehavior;
		private BasicBoss self;
		
		#region SkillState implementation

		public void execute () {
			moveBehavior.execute(self.target.position);
		}

		public void enter (BasicBoss boss) {
			self = boss;
			moveBehavior = new MoveBehavior(boss,  self.maxAttackVelocity, delegate {
				
			});
			moveBehavior.waypoint = self.target.position;
			
		}

		public void exit ()	{
			Destroy(this);
		}

		#endregion

	}
}