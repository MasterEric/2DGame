using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class LevelExit : MonoBehaviour {
	bool isActiviated = false;

	GameObject blockExit;

	void Awake() {
		this.tag = "TopExit";
		this.GetComponent<Collider2D>().isTrigger = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("Exit Trigger");
		if(!isActiviated && other.GetComponent<Player>() != null) {
			isActiviated = true;
			Vector3 blockpos = this.transform.position + Vector3.left + Vector3.left + Vector3.down;
			blockExit = (GameObject)Instantiate(LevelManager.GetLevelManager().blockPrefab, blockpos, Quaternion.identity);
			LevelManager.GetLevelManager().MoveQueueUp();
		}
	}
	
	void OnDestroy() {
		if(blockExit != null)
			Destroy(blockExit.gameObject);
	}
}
