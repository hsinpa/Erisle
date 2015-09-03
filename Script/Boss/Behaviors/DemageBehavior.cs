using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
	public class DemageBehavior {
		BasicBoss self;
		int undertakeDamage = 0;

		public DemageBehavior(BasicBoss boss) {
			self = boss;
		}

		public void demaged(JSONObject info) {
			string demageType = info.GetField("type").str;
			int demage = (int)info.GetField("demage").n;
			self.hp -= demage;

			if (self.hp <= 0 ) {
				//DIE
			}

			List<JSONObject> effectList = info.GetField("effectList").list;

		}

		public void golemEffect(float n, int endureN) {
			undertakeDamage += (int)n;
			if (undertakeDamage >= endureN) {
				undertakeDamage = 0;
			}
		}

		public void effectHandler(List<JSONObject> effects) {

			foreach(JSONObject effect in effects) {
				effectAttacher(effect);
			}
		}

		public void effectAttacher(JSONObject json) {
			switch (json.GetField("name").str) {
				case "freeze" :
				break;
				case "burn" :
				break;
				case "poison" :
				break;
				case "stun" :
				break;
				case "push" :
				break;
				default :
				break;
			}
		}

	}
}