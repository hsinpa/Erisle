using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public interface State {
	void execute();
	void enter(MonsterUnit enemy);
	void exit();
}