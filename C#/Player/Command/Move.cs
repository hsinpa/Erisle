using UnityEngine;
using System.Collections;

namespace Command_Input {
	public class Move : MonoBehaviour, Command {
		Input_Handler mainInput;

		#region Command implementation
		public void execute ()
		{
			throw new System.NotImplementedException ();
		}
		public void enter (Input_Handler input) {
			mainInput = input;
		}
		public void exit ()
		{
			throw new System.NotImplementedException ();
		}
		#endregion
	}
}