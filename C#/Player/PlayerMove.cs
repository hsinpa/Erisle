using UnityEngine;
using System.Collections;

public class PlayerMove : MoveClass 
{
	public Transform m_CameraDir;	//攝影機角度
	private Input_Handler inputHandler;
	static public bool SightSwitch = false ;
	void Start () 
	{
		if (!m_CharCtrl) this.enabled = false;
		if (!m_Ani) this.enabled = false;
		inputHandler = gameObject.GetComponent<Input_Handler>();
	}
	void Update () 

	{

		if(m_CanCtrl)
		{
			CharacterMove();
			CharacterAni();
			CharacterRotation();
		}
		//所有計算完成,應用移動數據
		m_CharCtrl.Move (MoveDir * Time.deltaTime);
	}

	//物理Updae
	void FixedUpdate()
	{
		if (m_UseGrivate)
		{
			Grivate();
		}
	}
	//重力計算
	public void Grivate()
	{
		if (!m_CharCtrl.isGrounded)
		{
			m_isGround = false;
			MoveDir.y -= m_Grivate * Time.deltaTime;
		}
		else
		{
			m_isGround = true;
		}
		//限制最大掉落速度 = 重力*2
		if (MoveDir.y <= -m_Grivate*2 && m_Grivate != 0)
		{
			MoveDir.y = -m_Grivate*2;
		}
	}
	//動畫控制
	public void CharacterAni()
	{
		AnimatorStateInfo currentState = m_Ani.GetCurrentAnimatorStateInfo(0);
		if (inputHandler.Attack_Num < 1 && inputHandler.currentState == Player.State.Idle) {
			if (SightSwitch == false) {

				if ((Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.D))) {
					m_Ani.SetBool ("Run", true);
				} else {
					m_Ani.SetBool ("Run", false);
				}

			}else{
				if ((Input.GetKey (KeyCode.W)) ) {
					m_Ani.SetFloat ("RunDirection1", 0);
				} else {

				if ((Input.GetKey (KeyCode.S)) ) {
						m_Ani.SetFloat ("RunDirection1", 1);
				} else {
				if ((Input.GetKey (KeyCode.A)) ) {
							m_Ani.SetFloat ("RunDirection1", 2);
				} else {
				if ((Input.GetKey (KeyCode.D)) ) {
								m_Ani.SetFloat ("RunDirection1", 3);
				} else {
								m_Ani.SetFloat ("RunDirection1", 4);
				}
						}
					}
				}

			}
		}
		else
		{
			m_Ani.SetBool("Run",false);
		}

	}
	//移動計算
	public void CharacterMove()
	{

		//用動畫判斷移動,MoveDir是移動的向量,其Y軸是重力
		if (m_Ani.GetBool("Run"))
		{
			//移動時以角色的正前方 * 移動速度為移動向量
			MoveDir = transform.forward * m_MoveSpeed + new Vector3(0,MoveDir.y,0    );
		}
		else
		{
			MoveDir.x = 0;
			MoveDir.z = 0;
		}
		
	}
	//旋轉計算
	public void CharacterRotation()
	{
		if (SightSwitch == false) { //射擊模式
		
			float yVelocity = 0.0F;

			if (Input.GetKey (KeyCode.W) & Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 45, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.W) & Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 45, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.S) & Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 135, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.S) & Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 135, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.W)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 90, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.S)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 180, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 90, ref yVelocity, m_RotaSpeed), 0);
			}
		} else {
			/*float yVelocity = 0.0F;
			if (Input.GetKey (KeyCode.W) & Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.W) & Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.S) & Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.S) & Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.W)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.A)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.S)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			} else if (Input.GetKey (KeyCode.D)) {
				transform.eulerAngles = new Vector3 (0, Mathf.SmoothDampAngle (transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
			}*/
		}



	}
}
