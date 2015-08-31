using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Boss {
	public class AttackBehavior {


		public string getAttackAnimate(List<AttackSet> attackSet) {
			int maxP = 100;
			int randomP = UnityEngine.Random.Range(1, 100);
			for (int i = 0; i < attackSet.Count; i++) {

				if (randomP <= maxP && randomP >= attackSet[i].chance) {
					return attackSet[i].name;
				}
				maxP = attackSet[i].chance;
			}

			return attackSet[0].name;
		}




	}
}