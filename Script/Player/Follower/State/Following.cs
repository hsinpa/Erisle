using UnityEngine;
using System.Collections;

namespace Follower {
	public class Following : MonoBehaviour, FollowerState{

		private FollowerManager self;

		
		#region SkillState implementation
		public void execute () {

		}
		
		public void enter (FollowerManager follower) {
			self = follower;
		}
		
		public void exit ()	{
			Destroy(this);
		}
		#endregion

	}
}