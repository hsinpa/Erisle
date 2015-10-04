using UnityEngine;
using System.Collections;

namespace Boss {
	public interface BehaviorState {
		void enter(BasicBoss boss);
	}
}