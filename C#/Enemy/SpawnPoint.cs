using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour {
	public int spawnRange = 15;
	public int territoryRange = 30;
	private int terrainLayer = 1 << 8;
	[HideInInspector]
	public JSONObject monsterData;
	public GameObject spawnMonsterType;
	public int spawnNum = 10;
	
	void Start() {
		spawnUnit();
		TextAsset bindata= Resources.Load("JSON/monsterData") as TextAsset;
		monsterData = new JSONObject(bindata.ToString());
	}
	
	//Spawnunit(Recursion)
	void spawnUnit() {
		if (spawnNum > 0) {
			List<Vector3> points = getSpawnPos();
			RaycastHit hitInfo;
			if (Physics.Linecast(points[0], points[1], out hitInfo, terrainLayer)) {
				GameObject monster = Instantiate(spawnMonsterType, hitInfo.point, transform.rotation) as GameObject;
				monster.GetComponent<MonsterUnit>().centerPoint = this;
				spawnNum--;
			}
			
			spawnUnit();
		}
	}
	
	public List<Vector3> getSpawnPos() {
		List<Vector3> spwanPoints = new List<Vector3>();
		float randomNumX = Random.Range(-spawnRange, spawnRange);
		float randomNumZ = Random.Range(-spawnRange, spawnRange);
		
		spwanPoints.Add( new Vector3(transform.position.x + randomNumX, 30, transform.position.z + randomNumZ));
		spwanPoints.Add( new Vector3(transform.position.x + randomNumX, -10, transform.position.z + randomNumZ));
		return spwanPoints;
	}
}
