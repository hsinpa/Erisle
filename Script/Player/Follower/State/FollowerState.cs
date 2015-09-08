using UnityEngine;
using System.Collections;

namespace Follower {
	public interface FollowerState {

		void execute();
		void enter(FollowerManager follower);
		void exit();
	}
}