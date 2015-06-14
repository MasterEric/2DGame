using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent( typeof( BoxCollider2D ), typeof( Rigidbody2D ) )]
public class BasicCharacterController : MonoBehaviour {
	
	public enum Direction {
		UP = 0,
		DOWN = 1,
		LEFT = 2,
		RIGHT = 3
	}

	public float jumpForce = 1.0f;
	public float verticalJumpThreshold = 0.4f;
	public float horizontalPower = 10;

	public LayerMask groundLayers;

	//Hardcoded values because I'm a lazy bum.
	public Transform groundedUp_top_left;
	public Transform groundedUp_bottom_right;
	public Transform groundedDown_top_left;
	public Transform groundedDown_bottom_right;
	public Transform groundedLeft_top_left;
	public Transform groundedLeft_bottom_right;
	public Transform groundedRight_top_left;
	public Transform groundedRight_bottom_right;

	[HideInInspector]
	public BoxCollider2D charBoxCollider;
	[HideInInspector]
	public Rigidbody2D charRigidbody2D;

	LineRenderer lr;

	void Start() {
		this.charBoxCollider = GetComponent<BoxCollider2D>();
		this.charRigidbody2D = GetComponent<Rigidbody2D>();
		lr = GetComponent<LineRenderer>();
	}

	void FixedUpdate () {
		lr.SetPosition(0, groundedUp_top_left.position);
		lr.SetPosition(1, groundedUp_bottom_right.position);

		Debug.Log ("Fixed update.");
		//if(IsGrounded (Direction.DOWN)) {
			Debug.Log ("Block is grounded downwards.");
			if(InputManager.verticalAxis >= verticalJumpThreshold || InputManager.jumpButton) {
				Debug.Log ("Jump!");
				charRigidbody2D.AddForce(Vector3.up * 300);
			}
		//}
		Debug.Log ("Left/Right Axis: "+InputManager.horizontalAxis);
		Debug.Log ("Up/Down Axis: "+InputManager.verticalAxis);
		
		charRigidbody2D.AddForce(Vector2.right * InputManager.horizontalAxis, ForceMode2D.Impulse);
	}

	public bool IsGrounded(Direction d) {
		switch(d) {
			case Direction.UP:
				return Physics2D.OverlapArea(groundedUp_top_left.position, groundedUp_bottom_right.position).IsTouchingLayers(groundLayers);
			case Direction.DOWN:
				return Physics2D.OverlapArea(groundedDown_top_left.position, groundedDown_bottom_right.position).IsTouchingLayers(groundLayers);
			case Direction.LEFT:
				return Physics2D.OverlapArea(groundedLeft_top_left.position, groundedLeft_bottom_right.position).IsTouchingLayers(groundLayers);
			case Direction.RIGHT:
				return Physics2D.OverlapArea(groundedRight_top_left.position, groundedRight_bottom_right.position).IsTouchingLayers(groundLayers);
			default:
				return false;
		}
	}
}

