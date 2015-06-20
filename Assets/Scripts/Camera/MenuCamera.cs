using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {
	bool hasMadeTarget = false;
	Vector3 start;
	Vector3 target;
	float journeyLength;
	float startTime;

	public float speed = 5f;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!hasMadeTarget && LevelManager.GetLevelManager().levelQueue[2] != null) {
			hasMadeTarget = true;
			start = transform.position;
			target = LevelManager.GetLevelManager().levelQueue[2].GetExitPositionVector3() + (Vector3.back * 10);
			startTime = Time.time;
			journeyLength = Vector3.Distance(start, target);
		} else {
			if(transform.position == target) {
				hasMadeTarget = false;
				LevelManager.GetLevelManager().MoveQueueUp();
				return;
			} else {
				float distCovered = (Time.time - startTime) * speed;
				float progress = distCovered / journeyLength;
				Vector3 lerp = Vector3.Lerp(start, target, progress);
				//Debug.Log ("Lerp: "+lerp);
				transform.position = lerp;
			}
		}	
	}
}
