using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class SearchBehavior  {
	
		BasicBoss self;
		Action<Transform> reachCallback;
		int targetLayer;
		
		public SearchBehavior (BasicBoss boss,int layer,Action<Transform> callback) {
			self = boss;
			reachCallback = callback;
			targetLayer = layer;
		}
		
		
		public void execute() {
			Collider[] hitColliders = Physics.OverlapSphere(self.transform.position, self.searchRadius, targetLayer);
			if (hitColliders.Length > 0) reachCallback(hitColliders[0].transform);
		}
		
		
		
		
	}
}