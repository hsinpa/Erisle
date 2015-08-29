using UnityEngine;
using System.Collections;

public class example1 : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {

		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			print(contact.point);
		}

		
	}
}