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
<<<<<<< HEAD
            //Increment score.
			if(ScoreManager.DoesScoreManagerExist()) {
                ScoreManager.GetScoreManager().ChangeLevel()
            }
=======
>>>>>>> 8e53df92d08e0fee3f6014e481ac923da96ace60
		}
	}
	
	void OnDestroy() {
		if(blockExit != null)
			Destroy(blockExit.gameObject);
	}
}
