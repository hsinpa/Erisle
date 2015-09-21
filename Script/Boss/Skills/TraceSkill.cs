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
			Gizmos.DrawLine(transform.position, transform.position + Vector3.up +transform.forward  * 3f);
		}

		IEnumerator checkRangeAttackTime(float waitTime) {
			yield return new WaitForSeconds(waitTime);
			float distance = Vector3.Distance(self.target.position, self.transform.position);
			
			if ( distance > 5 ) {
				self.changeState(gameObject.AddComponent<AttackSkill>());
			} else {
				StartCoroutine(checkRangeAttackTime(2));
			}
		}

		

		public void enter (BasicBoss boss) {
			self = boss;
			moveBehavior = new MoveBehavior(boss,  self.maxAttackVelocity, delegate {
				if (Physics.Linecast(transform.position, transform.position + Vector3.up + transform.forward * 3f, self.playerLayer)) {
					self.changeState(gameObject.AddComponent<AttackSkill>());
				}
			});
			StartCoroutine(checkRangeAttackTime(3));
			self.state = BasicBoss.BossState.Move;
		}

		public void exit ()	{
			Destroy(this);
		}

		#endregion

	}
}