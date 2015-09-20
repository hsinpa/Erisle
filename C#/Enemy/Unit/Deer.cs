using UnityEngine;
using System.Collections;

public class Deer : MonsterUnit {
	
	void Start() {
		//Defualt Search
		base.Start();
		currentState = gameObject.AddComponent<EnemyFSM.Search>();
		currentState.enter(this);
	}
	
	protected void FixedUpdate () {
		base.FixedUpdate();
		
	}

	protected override void checkVisibiltiy(Transform target) {
		changeState(gameObject.AddComponent<EnemyFSM.Escape>());
	}
}
