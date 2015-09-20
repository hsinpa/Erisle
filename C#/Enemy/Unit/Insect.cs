using UnityEngine;
using System.Collections;
using System;
public class Insect: MonsterUnit  {

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