using UnityEngine;
using System.Collections;


namespace Follower {
	public class FollowerManager : MonoBehaviour {
		public Transform player;
		public FollowerState currentState;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void changeState(FollowerState newState) {
			currentState.exit();
			currentState = newState;
			newState.enter(this);
		}
	}
}