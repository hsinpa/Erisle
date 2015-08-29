using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnemyFSM {
	public class Search : MonoBehaviour, State {
		private MonsterUnit self;
		public Vector3 waypoint = Vector3.zero;
		private int terrainLayer = 1 << 8;
		private int playerLayer = 1 << 10;
		
		public void enter (MonsterUnit enemy) {
			self = enemy;
			setWayPoint();
			float ranSecond = Random.Range(1, 10);
			InvokeRepeating("setWayPoint", ranSecond, 5F);
		}
		
		public void execute () {
			moveToWayPoint();
			//self.selfRigidbody.velocity = force;
			self.fieldInspection();
			transform.LookAt(waypoint);
		}


		private void moveToWayPoint() {
			float distance = Vector3.Distance(waypoint, self.transform.position);
			
			if ( distance > 1) {
				Vector3 moveDir = transform.forward * self.maxWalkVelocity + new Vector3(0,self.MoveDir.y,0);
				self.m_CharCtrl.Move(moveDir * Time.deltaTime);
				self.anim.SetFloat("Speed", 1);
				
			} else {
				self.anim.SetFloat("Speed", 0);
			}
		}
		
//		private void moveToWayPoint() {
//			Vector3 desired_velocity = waypoint - self.transform.position;
//			float distance = Vector3.Distance(waypoint, self.transform.position);
//			
//			if (distance < self.slowRadius && distance > 2) {
//				// Inside the slowing area
//				desired_velocity = Vector3.Normalize(desired_velocity) * self.maxWalkVelocity * (distance / self.slowRadius) - self.selfRigidbody.velocity;
//				transform.Translate(Vector3.forward * self.maxWalkVelocity * Time.deltaTime);
//			} else if (distance < 1) {
//				desired_velocity = Vector3.zero;
//
//			} else {
//				// Outside the slowing area.
//				if (self.selfRigidbody.velocity.magnitude < 10) {
//					desired_velocity = Vector3.Normalize(desired_velocity) * self.maxWalkVelocity - self.selfRigidbody.velocity;
//				}
//				transform.Translate(Vector3.forward * self.maxWalkVelocity * Time.deltaTime);
//			}
//			self.anim.SetFloat("Speed", desired_velocity.magnitude);
//
//			return desired_velocity;
//		}
		
		protected void setWayPoint() {
			List<Vector3> points = self.centerPoint.getSpawnPos();
			
			RaycastHit hitInfo;
			if (Physics.Linecast(points[0], points[1], out hitInfo, terrainLayer)) {
				waypoint = hitInfo.point;
			} else { 
				setWayPoint();
			}
		}
		
		public void exit () {
			Destroy(this);
		}
	}
}