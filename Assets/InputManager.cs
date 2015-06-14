using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public static float horizontalAxis {
		get { return Input.GetAxis("Horizontal"); }
	}
	public static float verticalAxis {
		get { return Input.GetAxis("Vertical"); }
	}
	public static bool jumpButtonOneShot {
		get { return Input.GetButtonDown("Jump"); }
	}
	public static bool jumpButton {
		get { return Input.GetButton("Jump"); }
	}
}