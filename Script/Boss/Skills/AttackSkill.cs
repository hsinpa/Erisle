﻿using UnityEngine;
using System.Collections;

namespace Boss {
	public class AttackSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private AttackBehavior attackBehavior;
		private MoveBehavior moveBehavior;

		#region SkillState implementation
		
		public void execute () {
		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			attackBehavior = new AttackBehavior();

			string attackMethod = attackBehavior.getAttackAnimate( self.attackSets );
			self.m_Ani.SetTrigger(attackMethod);
		}
		
		public void exit ()	{
			Destroy(this);
		}
		
		#endregion


		public void Fire() {
			Debug.Log("Fire");
		}

		public void Hold() {
			self.changeState(gameObject.AddComponent<TraceSkill>());
		}
	}
}