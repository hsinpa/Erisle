using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameUI {
	public class UserInfo : MonoBehaviour {
		Player player;
		Text userInfo;
		// Use this for initialization
		void Start () {
			player = GameObject.Find("Albert").GetComponent<Player>();
			userInfo = GetComponent<Text>();
		}
		
		// Update is called once per frame
		void Update () {
			userInfo.text = "HP : " + player.hp +"\nArmor : " + player.armor; 
		}
	}
}