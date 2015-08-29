using UnityEngine;
using System.Collections;

namespace Boss {
public class BasicBoss : MoveClass {
	public float hp = 100;
	public Animator anim;

	void Start() {
		anim = gameObject.GetComponent<Animator>();
	}

	}
}
