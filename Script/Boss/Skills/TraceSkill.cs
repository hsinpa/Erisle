using UnityEngine;
using System.Collections;

namespace Boss {
	public class TraceSkill : MonoBehaviour, SkillState {
		private MoveBehavior moveBehavior;
		private BasicBoss self;
		
		#region SkillState implementation

		public void execute () {
			moveBehavior.waypoint = self.target.position;
			moveBehavior.turnToDirection();
			moveBehavior.moveToPoint();
			moveBehavior.checkOutOfVision();
		}
		
		void OnDrawGizmos() {
				Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5f);
		}
		

		public void enter (BasicBoss boss) {
			self = boss;
			moveBehavior = new MoveBehavior(boss,  self.maxAttackVelocity, delegate {
				if (Physics.Linecast(transform.position, transform.position + transform.forward * 5f, self.playerLayer)) {
					self.changeState(gameObject.AddComponent<AttackSkill>());
				}
			});
		}

		public void exit ()	{
			Destroy(this);
		}

		#endregion

	}
}