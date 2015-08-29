using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Input_Handler : MonoBehaviour {
	public Animator anim;
	public Player.State currentState;
    public int Attack_Num = 0;
	public float Attack_Time = 0;
	public List<Command> commandBuffer;
	public SwordCollideDetector swordCollider;

	//Command Input
	private Command attack1Button;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		swordCollider = transform.GetComponentInChildren<SwordCollideDetector>();
		attack1Button = new Command_Input.Attack_1(this);
		currentState = Player.State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		handleInput();
	}

	private void handleInput() {
		if (Input.GetButtonDown(PlayerPrefs.GetString("Attack1","Fire2"))) attack1Button.execute();

		if (Time.time > Attack_Time) {
			Attack_Num=0;
			currentState = Player.State.Idle;
			swordCollider.goAttack = false;
			anim.SetInteger("Attack1_Num", 0);
		}
	}

	public void executeCommandBuffer() {
		if (commandBuffer.Count > 0) {
			commandBuffer[commandBuffer.Count-1].execute();
			commandBuffer.Clear();
		}
	}


	public void Zero (){
		print("77");
		anim.SetInteger("Attack1_Num", 0);
		Attack_Num = 0;
		
	}

}
