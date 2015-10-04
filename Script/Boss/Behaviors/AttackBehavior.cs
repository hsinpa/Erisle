using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Boss {
	public class AttackBehavior {


		public JSONObject getAttackAnimate(List<JSONObject> attackSet) {
			float maxP = 100;
			int randomP = UnityEngine.Random.Range(1, 100);
			for (int i = 0; i < attackSet.Count; i++) {

				if (randomP <= maxP && randomP >= attackSet[i].GetField("chance").n) {
					return attackSet[i];
				}
				maxP = attackSet[i].GetField("chance").n;
			}

			return attackSet[0];
		}
	}
}