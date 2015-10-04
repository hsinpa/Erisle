using UnityEngine;
using System.Collections;

namespace Boss {
	public struct AttackSet {
		public string name;
		public int chance;

		public AttackSet(string n, int c) {
			name = n;
			chance = c;
		}

	}
}
