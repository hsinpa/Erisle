using UnityEngine;
using System.Collections;

namespace Boss {
	public class BossAttackCollider : MonoBehaviour {
		public bool on = false;
		public JSONObject attackInfo;


		void OnTriggerStay(Collider other) {
			if(on && other.gameObject.tag == "Player") {
				on = false;
				//Deduct enemy's hp
				other.gameObject.GetComponent<Player>().underBossAttack(attackInfo);
			}
		}
	}
}