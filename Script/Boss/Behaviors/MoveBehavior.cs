using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Boss {

	public class MoveBehavior  {
		public Vector3 waypoint;
		BasicBoss self;
		Action reachCallback;
		int mSpeed;
		
		public MoveBehavior (BasicBoss boss, int speed, Action callback) {
			self = boss;
			reachCallback = callback;
			mSpeed = speed;
		}
		
		public List<Vector3> getSpawnPos() {
			List<Vector3> spwanPoints = new List<Vector3>();
			float randomNumX = UnityEngine.Random.Range(-self.spawnRange, self.spawnRange);
			float randomNumZ = UnityEngine.Random.Range(-self.spawnRange, self.spawnRange);
			spwanPoints.Add( new Vector3(self.transform.position.x + randomNumX, 30, self.transform.position.z + randomNumZ));
			spwanPoints.Add( new Vector3(self.transform.position.x + randomNumX, -10, self.transform.position.z + randomNumZ));
			return spwanPoints;
		}
		
		public void setWayPoint() {
			List<Vector3> points = getSpawnPos();
			RaycastHit hitInfo;
			if (Physics.Linecast(points[0], points[1], out hitInfo, self.terrainLayer)) {
				waypoint = hitInfo.point;
				turnToDirection();
			} else {
				setWayPoint();
			}
		}

		public void checkOutOfVision() {
			float distance = Vector3.Distance(waypoint, self.transform.position);
			if (distance > self.loseVisionRange) {
				self.changeState(self.gameObject.AddComponent<WanderSkill>());
			}
		}
		
		public void turnToDirection() {
			float delay = 80f;
			Vector3 normalizedDirection = Vector3.Normalize(new Vector3(waypoint.x, self.transform.position.y, waypoint.z) -self.transform.position);
			Hashtable hashtable = new Hashtable();
			hashtable.Add("rotation", Quaternion.LookRotation(normalizedDirection).eulerAngles);
			hashtable.Add("speed", delay);
			
			iTween.RotateTo(self.gameObject, hashtable);
		}			
		
		public void execute() {
				float distance = Vector3.Distance(waypoint, self.transform.position);
				Vector3 moveDir = self.transform.forward * Time.deltaTime * mSpeed;
				self.m_CharCtrl.Move( moveDir  + new Vector3(0,self.MoveDir.y,0));
				
				if ( distance < 2f) {
					reachCallback();
				}
			
		}
		
	}
}