using UnityEngine;
using System.Collections;

namespace EnemyFSM.AttackMode {
	public interface Method {
		bool checkCanAttack(float distance, float hp, Animator anim, Transform transform);
	}
}