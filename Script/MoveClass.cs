using UnityEngine;
using System.Collections;
//移動類別,所有需要複雜移動的物件都需要繼承此
public abstract class MoveClass : MonoBehaviour {
	public CharacterController m_CharCtrl;//角色控制器
	public Animator m_Ani;//Animator控制器
	public float m_MoveSpeed;//移動速度
	public float m_RotaSpeed;//旋轉速度
	public float m_Grivate = 9.8f;//重力
	public float m_JumpHeight = 4;  //跳躍高度
	public bool m_CanCtrl = true;//是否能控制
	public bool m_UseGrivate = true;//是否使用重力
	[HideInInspector]
	public bool m_isGround = true;
	//[HideInInspector]
	public Vector3 MoveDir = Vector3.zero;
	
	void Awake () 
	{
		if (!m_CharCtrl) 
		{
			try
			{
				m_CharCtrl = GetComponent<CharacterController>();
			}catch
			{
				Debug.LogError("沒有角色控制器參數");
			}
		}

		if (!m_Ani)
		{
			try
			{
				m_Ani = GetComponent<Animator>();
			}catch
			{
				Debug.LogError("沒有動畫控制器參數");
			}
		}
	}

	public void calculateGrivaty() {
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
}
