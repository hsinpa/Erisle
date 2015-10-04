using UnityEngine;
using System.Collections;
namespace Boss {
	public interface SkillState {
			void execute();
			void enter(BasicBoss boss);
			void exit();
	}
}