using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class StoneGolemManager : BasicBoss {

		
		void Start() {
			//Defualt Search
			base.Start();
			currentState = gameObject.AddComponent<WanderSkill>();
			currentState.enter(this);
		}
		
		protected void FixedUpdate () {
			currentState.execute();
			base.FixedUpdate();
		}
	}
}