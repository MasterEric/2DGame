using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	//Instance
	public Level tutorialLevel;	
	//Prefabs
	public Level[] levelList;

	//0-1-2-3-4
	//4 was just added
	//0 is about to be removed
	//2 is the current room
	[HideInInspector]
	public Level[] levelQueue;
	
	// Use this for initialization
	void Start () {
		levelQueue = new Level[5];
		//Load first 3 levels.
		levelQueue[2] = tutorialLevel.GetComponent<Level>();
		levelQueue[3] = AddLevel(GetRandomPrefabIndex());
		levelQueue[4] = AddLevel(GetRandomPrefabIndex());
	}
	
	int GetRandomPrefabIndex() {
		return Random.Range(0, levelList.Length);
	}

	//Loads 
	Level AddLevel(int prefabIndex) {
		return Instantiate(levelList[prefabIndex].gameObject).GetComponent<Level>();

	}

	void PositionLevel(Level anchorLevel, Level movingLevel) {

	}

	void Update () {
		
	}
}
