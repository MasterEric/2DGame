using UnityEngine;
using System.Collections;

public class CameraLockOnTarget : MonoBehaviour {

	public Transform targetToLockOnTo;
	public float Zpos;

	void Update () {

		this.transform.position = new Vector3(targetToLockOnTo.position.x, targetToLockOnTo.position.y, Zpos);
	
	}
}
