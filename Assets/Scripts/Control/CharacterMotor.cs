using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D), typeof(GroundChecker), typeof(UserControl))]
public class CharacterMotor : MonoBehaviour {
	//Configuration variables.
	public float movementSpeed = 10f;
	public float maxHorizontalSpeed = 25f;
	public float jumpSpeed = 500f;
	public float wallJumpSideSpeed = 1000f;
	public float wallJumpUpSpeed = 750f;

	public float cooloffFactor = 0.4f;

	public float wallJumpLeftCooloff = 0.5f;
	bool wallJumpLeftCooloffOn = false;
	float wallJumpLeftCooloffTimer = 0.0f;	
	public float wallJumpRightCooloff = 0.5f;
	bool wallJumpRightCooloffOn = false;
	float wallJumpRightCooloffTimer = 0.0f;

	Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		this.rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		if(wallJumpLeftCooloffOn) {	
			wallJumpLeftCooloffTimer += Time.deltaTime;
			if(wallJumpLeftCooloffTimer > wallJumpLeftCooloff) {
				wallJumpLeftCooloffOn = false;
				wallJumpLeftCooloffTimer = 0.0f;
			}
		}
		if(wallJumpRightCooloffOn) {	
			wallJumpRightCooloffTimer += Time.deltaTime;
			if(wallJumpRightCooloffTimer > wallJumpRightCooloff) {
				wallJumpRightCooloffOn = false;
				wallJumpRightCooloffTimer = 0.0f;
			}
		}		
	}

	public void Move (float horizontal, GroundChecker.Direction m_Jump) {
		//Add vertical velocity, preventing reset of gravity.
		switch(m_Jump) {
			case GroundChecker.Direction.TOP:
				//Jump off... the ceiling? No.
				break;
			case GroundChecker.Direction.BOTTOM:
				//Jump off the ground.
				//Debug.Log ("JumpUpWall");
				rigidBody.AddForce((Vector2.up * jumpSpeed));
				break;
			case GroundChecker.Direction.LEFT:
				//Jump off the left wall, to the right.
				//Debug.Log ("JumpLeftWall");
				rigidBody.AddForce((Vector2.right * wallJumpSideSpeed));
				rigidBody.AddForce((Vector2.up * wallJumpUpSpeed));
				wallJumpLeftCooloffOn = true;
				break;
			case GroundChecker.Direction.RIGHT:
				//Jump off the right wall, to the left.
				//Debug.Log ("JumpRightWall");
				rigidBody.AddForce((Vector2.left * wallJumpSideSpeed));
				rigidBody.AddForce((Vector2.up * wallJumpUpSpeed));
				wallJumpRightCooloffOn = true;
				break;
			case GroundChecker.Direction.NONE:
				//No jump.
				break;
			default:
				//Just in case.
				break;
		}
		float h;
		if(Mathf.Abs(rigidBody.velocity.x) >= maxHorizontalSpeed) {
			if(rigidBody.velocity.x > 0)
				h = maxHorizontalSpeed;
			else
				h = -maxHorizontalSpeed;
		} else {
			if((horizontal > 0 && wallJumpRightCooloffOn) || (horizontal < 0 && wallJumpLeftCooloffOn)) {
				//Debug.Log ("Cooldown movement override");
				h = rigidBody.velocity.x + horizontal*movementSpeed*cooloffFactor;
			} else {
				h = horizontal * movementSpeed + rigidBody.velocity.x;
			}	
		}

		rigidBody.velocity = new Vector2(h, rigidBody.velocity.y);

	}
}
