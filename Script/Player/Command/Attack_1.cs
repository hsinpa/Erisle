using UnityEngine;
using System.Collections;

namespace Command_Input {
	public class Attack_1 : MonoBehaviour, Command {
		Input_Handler mainInput;

		public Attack_1(fps xxx ) {

		}

		public Attack_1(Input_Handler input) {
			mainInput = input;
		}


		public void execute () {
			mainInput.swordCollider.goAttack = true;
			mainInput.Attack_Num++;
			mainInput.anim.SetInteger("Attack1_Num", mainInput.Attack_Num);
			mainInput.Attack_Time = Time.time + 0.5f;

			mainInput.transform.rotation = Quaternion.Euler(mainInput.transform.rotation.x, Camera.main.transform.eulerAngles.y, mainInput.transform.rotation.z);
			fps.playerspineA.transform.rotation = Quaternion.Euler(fps.playercamera.transform.rotation.x, fps.playerspineA.transform.eulerAngles.y, fps.playerspineA.transform.rotation.z);

		}
	   
	

		


		public void exit ()	{

		}




	}

}