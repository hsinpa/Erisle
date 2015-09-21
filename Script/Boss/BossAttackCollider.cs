using UnityEngine;
using System.Collections;

namespace Boss {
	public class BossAttackCollider : MonoBehaviour {
		public bool on = false;
		public float damage = 0;


		void OnTriggerStay(Collider other) {
			if(on && other.gameObject.tag == "Player") {
				on = false;
				//Deduct enemy's hp 
				Debug.Log("Damaged");
			}
		}
	}
}