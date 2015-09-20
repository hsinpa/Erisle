using UnityEngine;
using System.Collections;

namespace EnemyFSM {
	public class Escape : MonoBehaviour, State {

		private MonsterUnit self;
		private Transform target;
		private float speed = 4;
		private float safeRange = 16;

		public void enter (MonsterUnit enemy) {
			self = enemy;
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		
		public void execute () {
			Vector3 steer = escape();
			//self.selfRigidbody.velocity = steer;
		}
		
		public void exit () {
			Destroy(this);
		}

		private Vector3 escape() {

			Vector3 newPos = (self.transform.position - target.position) + self.transform.position;

			float distance = Vector3.Distance(target.position, self.transform.position);
			transform.LookAt(newPos); 
			self.m_CharCtrl.Move((transform.forward * self.maxAttackVelocity * Time.deltaTime) + new Vector3(0,self.MoveDir.y,0));


			if (distance > safeRange) {
				self.changeState(gameObject.AddComponent<EnemyFSM.Search>());
			}
			
			self.anim.SetFloat("Speed", newPos.magnitude);
			return newPos;
		}
	}
}
