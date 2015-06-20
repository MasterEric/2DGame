using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	//Instance
	public Level tutorialLevel;	
	//Prefabs
	public GameObject blockPrefab;
	public Level[] levelList;

	//0-1-2-3-4
	//4 was just added
	//0 is about to be removed
	//2 is the current room
	[HideInInspector]
	public Level[] levelQueue;

	public static LevelManager GetLevelManager() {
		return GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}	
	
	// Use this for initialization
	void Start () {
		this.tag = "LevelManager";
		levelQueue = new Level[5];	
		levelQueue[2] = tutorialLevel.GetComponent<Level>();
		levelQueue[3] = AddLevel(GetRandomPrefabIndex());
		PositionLevel(levelQueue[2], levelQueue[3]);
		levelQueue[4] = AddLevel(GetRandomPrefabIndex());
		PositionLevel(levelQueue[3], levelQueue[4]);
	}
	
	int lastIndex;
	int GetRandomPrefabIndex() {
		int x = Random.Range(0, (levelList.Length));
		if(x != lastIndex) {
			lastIndex = x;
			return x;
		} else {
			return GetRandomPrefabIndex();
		}
	}

	//Loads 
	Level AddLevel(int prefabIndex) {
		return Instantiate(levelList[prefabIndex].gameObject).GetComponent<Level>();
	}

	void PositionLevel(Level anchorLevel, Level movingLevel) {
		movingLevel.transform.position += Level.GetPositionOffset(anchorLevel.GetExitPosition(), movingLevel.GetEntrancePosition());
		movingLevel.transform.position += Vector3.left;
	}

	public void MoveQueueUp () {
		if(levelQueue[0] != null)
			levelQueue[0].DestroyLevel();
		
		levelQueue[0] = levelQueue[1];
		levelQueue[1] = levelQueue[2];
		levelQueue[2] = levelQueue[3];
		levelQueue[3] = levelQueue[4];
		levelQueue[4] = AddLevel(GetRandomPrefabIndex());
		PositionLevel(levelQueue[3], levelQueue[4]);
	}

}
