using UnityEngine;
using System.Collections;

namespace EnemyFSM.AttackMode {
	public class TriangleHead : MonoBehaviour,Method {

		private int jumpPower = 50;
		private float attackPeriod = 0;


		
		public bool checkCanAttack (float distance, float hp, Animator anim, Transform mTransform) {
			anim.SetFloat("Distance", distance);
			
			//Attack Mode
			if (distance < 5f && distance > 2f) {
				//Range
				//anim.SetTrigger("JumpAttack");
				if (Time.time > attackPeriod) {
					CharacterController cctrol = GetComponent<CharacterController>();
					attackPeriod = Time.time + 2;

					Debug.Log("JUmp");
				}

				return true;
			} else if (distance <= 2f) {
				//Melee
				//anim.SetBool("Attack", true);
				//particleCtrl(false);
				
				//Jump Backward
				return true;
				
			}
			//particleCtrl(false);
			return false;
		}
	}

}