using UnityEngine;
using System.Collections;

namespace Boss {
	public class JumpBehavior {
		BasicBoss self;
		
		public JumpBehavior (BasicBoss boss) {
			self = boss;
		}
		
		public void jumpToPosition(GameObject gameObject) {
			Vector3 distance = self.target.transform.position - self.transform.position;
		
			Hashtable hashtable = new Hashtable();
			hashtable.Add("x", gameObject.transform.position.x );
			hashtable.Add("y", gameObject.transform.position.y + 3.5f);
			hashtable.Add("z", gameObject.transform.position.z );
			hashtable.Add("easeType", "easeOutQuart");
			
			hashtable.Add("speed", 20);
			hashtable.Add("oncomplete", "Land");
			
			iTween.MoveTo(self.gameObject, hashtable);
			
		}
		
		public void jumpImpactCheck(JSONObject info) {
			float distance = Vector3.Distance( self.target.position , self.transform.position);
			Debug.Log(distance);
			if (distance < 5.5f) {
				self.target.GetComponent<Player>().underBossAttack(info);
			}
			
		}
		
	}
}