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

			if (self.state == BasicBoss.BossState.Stun)
				StartCoroutine(resumeFromNegativeState(stunTime));
		}


		IEnumerator resumeFromNegativeState(float waitTime) {
			yield return new WaitForSeconds(waitTime);
			self.m_Ani.SetBool("Stone", false);
			self.changeState(gameObject.AddComponent<TraceSkill>());
		}
		
		public void exit ()	{
			Destroy(this);
		}
	}
}