using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnemyFSM {
	public class Dead : MonoBehaviour, State {
		private MonsterUnit self; 
		public void enter (MonsterUnit enemy) {
			self = enemy;
			self.selfRigidbody.isKinematic = true;

			StartCoroutine(WaitAndDie(5.0F));
		}


		IEnumerator WaitAndDie(float waitTime) {
			yield return new WaitForSeconds(waitTime);
			Destroy(gameObject);
		}

		public void execute () {
			
		}
		
		public void exit () {
			
		}
	}
}