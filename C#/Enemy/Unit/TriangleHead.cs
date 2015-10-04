using UnityEngine;
using System.Collections;

public class TriangleHead : MonsterUnit {

	void Start() {
		//Defualt Search
		base.Start();
		currentState = gameObject.AddComponent<EnemyFSM.Search>();
		currentState.enter(this);
		
	}
	
	protected void FixedUpdate () {
		base.FixedUpdate();
		
	}
}
