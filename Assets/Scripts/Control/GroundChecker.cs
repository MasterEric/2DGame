using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {
	public LayerMask	GroundLayers;
	public Collider2D 	GroundCheckTopCollider;
	public Collider2D 	GroundCheckBottomCollider;
	public Collider2D 	GroundCheckLeftCollider;
	public Collider2D 	GroundCheckRightCollider;

	public enum Direction {
		TOP,
		BOTTOM,
		LEFT,
		RIGHT,
		OMNI,
		NONE
	}

	public bool IsGrounded (Direction d) {
		switch(d) {
			case Direction.TOP:
				return GroundCheckTopCollider.IsTouchingLayers(GroundLayers.value);
			case Direction.BOTTOM:
				return GroundCheckBottomCollider.IsTouchingLayers(GroundLayers.value);
			case Direction.LEFT:
				return GroundCheckLeftCollider.IsTouchingLayers(GroundLayers.value);
			case Direction.RIGHT:
				return GroundCheckRightCollider.IsTouchingLayers(GroundLayers.value);
			case Direction.OMNI:
				if(this.IsGrounded(GroundChecker.Direction.TOP) || this.IsGrounded(GroundChecker.Direction.BOTTOM) || this.IsGrounded(GroundChecker.Direction.LEFT) || this.IsGrounded(GroundChecker.Direction.RIGHT)){
					return true;
				} else {
					return false;
				}
			default:	
				return false;
		}
	}
}
