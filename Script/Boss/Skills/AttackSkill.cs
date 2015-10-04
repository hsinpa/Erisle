using UnityEngine;
using System.Collections;

namespace Boss {
	public class AttackSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private AttackBehavior attackBehavior;
		private JumpBehavior jumpBehavior;
		private GameObject rock;
		BossAttackCollider[] bossAttackColliders;

		#region SkillState implementation
		
		public void execute () {

		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			attackBehavior = new AttackBehavior();
			jumpBehavior = new JumpBehavior(self);
			bossAttackColliders = self.gameObject.GetComponentsInChildren<BossAttackCollider>();

			float distance = Vector3.Distance(self.target.position, self.transform.position);
			
			if ( distance > 5 ) {
				self.m_Ani.SetTrigger("Range");
				return;
			}

			JSONObject attackObject = attackBehavior.getAttackAnimate( self.bossData.GetField("AttackList").list );
			foreach(BossAttackCollider weapon in bossAttackColliders) {
				weapon.attackInfo = attackObject;
			}

			self.m_Ani.SetTrigger(attackObject.GetField("name").str);
		}
		
		public void exit ()	{
			Destroy(this);
		}
		
		
		#endregion
		private void attackState(BasicBoss.BossState state) {
			self.state = state;
			
			foreach(BossAttackCollider weapon in bossAttackColliders) {
				weapon.on = true;
			}
		}
		
		public void Fire() {
			Debug.Log("Fire");
			attackState(BasicBoss.BossState.Attack);
		}
		
		public void Range() {
			JSONObject weaponInfo = self.bossData.GetField("RangeWeapon");
			GameObject rangeWeapon = Resources.Load("Boss/"+weaponInfo.GetField("name").str) as GameObject;
			rock = Instantiate(rangeWeapon, self.target.position, rangeWeapon.transform.rotation) as GameObject;
			
			foreach(BossAttackCollider weapon in bossAttackColliders) {
				weapon.attackInfo = weaponInfo;
			}
		}
		
		public void Jump() {
			Debug.Log("Jump");
			
			self.transform.LookAt(rock.transform);
			attackState(BasicBoss.BossState.Attack);

			self.m_Ani.SetBool("Jump", true);
			
			jumpBehavior.jumpToPosition(rock);
			
		}
		
		
		public void Land() {
			Hashtable hashtable = new Hashtable();
			hashtable.Add("x", self.transform.position.x );
			hashtable.Add("y", self.transform.position.y -1.5f);
			hashtable.Add("z", self.transform.position.z );
			hashtable.Add("speed", 10);
			
			iTween.MoveTo(self.gameObject, hashtable);
			jumpBehavior.jumpImpactCheck(self.bossData.GetField("RangeWeapon"));
			self.m_Ani.SetBool("Jump", false);
		}
		
		public void Hold() {
			Debug.Log("Hold");
			self.changeState(gameObject.AddComponent<TraceSkill>());
			foreach(BossAttackCollider weapon in bossAttackColliders) {
				weapon.on = false;
			}
		}
	}
}