using UnityEngine;
using System.Collections;

public interface Command {
	void execute();
	void exit();
}
