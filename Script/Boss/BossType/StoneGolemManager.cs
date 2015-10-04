using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class StoneGolemManager : BasicBoss {
		int canEndureDemage = 200;

		void Start() {
			//Defualt Search
			base.Start();
			getBossData("StoneGolem");
			currentState = gameObject.AddComponent<IdleSkill>();
			currentState.enter(this);
//			attackSets.Add(new AttackSet("Normal", 50));
//			attackSets.Add(new AttackSet("Consecutive", 20));
//			attackSets.Add(new AttackSet("Tornado", 0));

		}
		
		protected void FixedUpdate () {
			currentState.execute();
			base.FixedUpdate();
		}

		public override void beDamaged(JSONObject json) {
			base.beDamaged(json);
			damagebehavior.golemEffect( json.GetField("demage").n, canEndureDemage );

		}


	}
}