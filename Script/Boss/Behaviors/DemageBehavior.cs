using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
	public class DemageBehavior {
		BasicBoss self;
		int undertakeDamage = 0;
		int maxStun = 2;
		int currentStun = 0;
		float fullHP;

		float periodhPLineToCheckPerNum;
		float periodhPLineToCheck;

		public DemageBehavior(BasicBoss boss) {
			self = boss;
			fullHP = self.hp;
			periodhPLineToCheckPerNum = fullHP / 10;
			periodhPLineToCheck = fullHP - periodhPLineToCheckPerNum;
		}

		public void demaged(JSONObject info) {
			string demageType = info.GetField("type").str;
			int demage = (int)info.GetField("demage").n;
			self.hp -= demage;

			if (self.hp <= 0 ) {
				//DIE
			}

			if (self.hp < periodhPLineToCheck) {
				stunHandler();
			}

			List<JSONObject> effectList = info.GetField("effectList").list;

		}

		public void stunHandler() {
			periodhPLineToCheck =  periodhPLineToCheck - periodhPLineToCheckPerNum;
			float remain = self.hp / fullHP;
			float stunChance = 1 - remain;
			float possibleStunChance = Random.Range(0, 1);
			if (stunChance > possibleStunChance && currentStun < maxStun) {
				currentStun++;
				self.m_Ani.SetTrigger("Stun");
				self.changeState(self.gameObject.AddComponent<StunSkill>());

			}
		}

		public void golemEffect(float n, int endureN) {
			undertakeDamage += (int)n;
			Debug.Log (undertakeDamage);
			if (undertakeDamage >= endureN && self.state != BasicBoss.BossState.Block) {
				undertakeDamage = 0;
				self.m_Ani.SetBool("Stone", true);
				self.state = BasicBoss.BossState.Block;
				self.changeState(self.gameObject.AddComponent<StunSkill>());
			}
		}

		public void effectHandler(List<JSONObject> effects) {

			foreach(JSONObject effect in effects) {
				effectAttacher(effect);
			}
		}

		public void effectAttacher(JSONObject json) {
			switch (json.GetField("name").str) {
				case "freeze" :
				break;
				case "burn" :
				break;
				case "poison" :
				break;
				case "stun" :
				break;
				case "push" :
				break;
				default :
				break;
			}
		}

	}
}