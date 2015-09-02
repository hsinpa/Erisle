using UnityEngine;
using System.Collections;

namespace Boss {
	public class IdleSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private SearchBehavior searchBehavior;

		public void execute () {
			searchBehavior.execute();
		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			searchBehavior = new SearchBehavior(boss, self.playerLayer, delegate(Transform target) {
				self.target = target;
				self.changeState(gameObject.AddComponent<TraceSkill>());
			});
			self.m_Ani.SetInteger("Move", 0);
		}
		
		public void exit ()	{
			Destroy(this);
		}

	}
}