using UnityEngine;
using System.Collections;

namespace EnemyFSM.AttackMode {
	public class Both : MonoBehaviour,Method {
		private int maxJump = 3;
		private bool firstJump = false;
		private bool secondJump = false;
		private int jumpNum = 0;
		private int jumpPower = 550;
		private float attackPeriod = 0;
		public ParticleSystem[] mParticleEffect;
		private GameObject mParticleBullet = Resources.Load<GameObject>("GameElement/ArcaneSpray");

		private void particleCtrl(bool on) {
			foreach (ParticleSystem particle in  mParticleEffect) {
				if (on && !particle.isPlaying)
					particle.Play();
				
				if (!on && particle.isPlaying)
					particle.Stop();

			}
		}


		public bool checkCanAttack (float distance, float hp, Animator anim, Transform mTransform) {
			anim.SetFloat("Distance", distance);

			//Jump Condition
			if (hp < 50 && !firstJump) {
				anim.SetTrigger("Backward");
				anim.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.2f, -1) * jumpPower);
				firstJump = true;
			} else if (hp < 30 && !secondJump) {
				anim.SetTrigger("Backward");
				anim.gameObject.GetComponent<Rigidbody>().AddForce((new Vector3(0, 0.2f, 0) - anim.transform.forward )* jumpPower);
				secondJump = true;
			}

			
			//Attack Mode
			if (distance < 6.5f && distance > 3f) {
				//Range
				anim.SetBool("Attack", true);
				if (Time.time > attackPeriod) {
					attackPeriod = Time.time + 2;
					Instantiate(mParticleBullet, new Vector3(mTransform.position.x, mTransform.position.y+0.1f, mTransform.position.z), mTransform.rotation);
				}
				//particleCtrl(true);
				return true;
			} else if (distance <= 2f) {
				//Melee
				anim.SetBool("Attack", true);
				//particleCtrl(false);

				//Jump Backward
				return true;

			}
			//particleCtrl(false);
			return false;
		}
	}
}