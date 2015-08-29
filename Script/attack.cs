using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	


	void Update () {
		//先取得目前狀態的資訊
		AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
		
		//然後直接比對名稱就好，但是狀態資訊中並不是用string來存，所以把名稱轉Hash來比對，格式[Layer name].[state name]
		if(currentState.nameHash == Animator.StringToHash("Base Layer.anim")) {
			Debug.Log("This is Anim 1");
		}
		if(currentState.nameHash == Animator.StringToHash("Base Layer.anim2")) {
			Debug.Log("This is Anim 2");
		}
		
		//或是先定義一個參數

	}
}
