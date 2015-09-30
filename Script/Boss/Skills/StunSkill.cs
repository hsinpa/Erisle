using UnityEngine;
using System.Collections;

namespace Boss {
	public class StunSkill: MonoBehaviour, SkillState {
		private BasicBoss self;
		int stunTime = 3;
		public void execute () {

		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			Debug.Log(self.m_Ani.GetBool("Block"));

			if (self.m_Ani.GetBool("Block")) {
				self.state = BasicBoss.BossState.Block;
				StartCoroutine(resumeFromNegativeState(stunTime));
			}
		}


		IEnumerator resumeFromNegativeState(float waitTime) {
			yield return new WaitForSeconds(waitTime);
			Debug.Log ("isBlock");
			self.m_Ani.SetBool("Block", false);
			self.changeState(gameObject.AddComponent<TraceSkill>());
		}
		
		public void exit ()	{
			Destroy(this);
		}

		public void Resume() {
			Debug.Log("Hold");
			self.changeState(gameObject.AddComponent<TraceSkill>());
		}

	}
}