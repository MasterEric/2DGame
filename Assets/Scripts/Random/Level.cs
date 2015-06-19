using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public bool isTutorial;

	Transform topEntrance;
	Transform topExit;
	
	public LevelExit levelExit;

	// Use this for initialization
	void Awake () {
		foreach(Transform child in transform) {
			foreach(Transform childTwo in child) {
				if(childTwo.tag == "TopEntrance" && !isTutorial)
					this.topEntrance = childTwo;
				if(childTwo.tag == "TopExit")
					this.topExit = childTwo;
			}
		}
		if(this.topEntrance == null && !isTutorial)
			Debug.LogWarning("Level "+this.name+" has no entrance. Be sure to set the TopEntrance tag!");
		if(this.topExit == null)
			Debug.LogWarning("Level "+this.name+" has no exit. Be sure to set the TopExit tag!");
	
		//if(!isTutorial)
		//	Debug.Log ("Level "+this.name+" Entrance:"+this.topEntrance.position+"/"+this.topEntrance.localPosition);
		//Debug.Log ("Level "+this.name+" Exit:"+this.topExit.position+"/"+this.topExit.localPosition);
		Debug.Log ("Level "+this.name);
		if(levelExit == null)
			Debug.Log("No exit! " +this.name);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public Vector2 GetEntrancePosition() {
		if(topEntrance == null)
			Debug.LogWarning("Entrance doesn't exist!");
		return this.topEntrance.position;
	}

	public Vector2 GetExitPosition() {
		if(topExit == null)
			Debug.LogWarning("Exit doesn't exist!");
		return this.topExit.position;
	}

	public static Vector3 GetPositionOffset(Vector2 vectorOne, Vector2 vectorTwo) {
		Vector2 v = vectorOne - vectorTwo;
		return new Vector3(v.x, v.y, 0);
	}

	public GameObject GetLevelObject() {
		return gameObject;
	}

	public void DestroyLevel() {
		Debug.Log ("Destroy!");
		Destroy(levelExit.gameObject);
		Destroy(this.gameObject);
	}
}
