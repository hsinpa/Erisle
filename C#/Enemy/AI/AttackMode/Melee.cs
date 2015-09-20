using UnityEngine;
using System.Collections;

namespace EnemyFSM.AttackMode {
	public class Melee : Method {

		public bool checkCanAttack (float distance, float hp, Animator anim, Transform transform) {
			if (distance < 1.6f) {
				//Melee
				anim.SetTrigger("Attack");
				return true;
			}
			return false;
		}

	}
}
