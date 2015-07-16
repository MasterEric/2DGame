using UnityEngine;
using System.Collections;
using Prime31;
using UnityStandardAssets.CrossPlatformInput;


public class DemoScene : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float maxVerticalSpeed = 10f;
	public float maxHorizontalSpeed = 20f;
	public float jumpHeight = 3f;
	
	public float wallJumpSideSpeed = 10f;
	public float wallJumpUpSpeed = 7.5f;

	public float smoothTime = 0.3f; //time it takes to dampen between 0 and full speed.

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	//private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;
	private Vector3 _runVelocity;
	private float _acceleration;

	GroundChecker m_GroundChecker;
	
	public int extraJumpCount = 1;	
	int m_Jump = 0;
	GroundChecker.Direction m_isJumping = GroundChecker.Direction.NONE;	

	public float wallJumpLeftCooloff = 0.25f;
	bool wallJumpLeftCooloffOn = false;
	float wallJumpLeftCooloffTimer = 0.0f;	
	public float wallJumpRightCooloff = 0.25f;
	bool wallJumpRightCooloffOn = false;
	float wallJumpRightCooloffTimer = 0.0f;

	Vector3 _wallJumpVelocity;
	float _wallJumpAcceleration;
	public float wallJumpTime = 2.75f;

	// Toxoid's vars

	private bool isTouchingSurface = true;

	// =============


	void Awake()
	{
		_controller = GetComponent<CharacterController2D>();
		m_GroundChecker = GetComponent<GroundChecker>();

	}




	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{

		isTouchingSurface = true;

	}


	void onTriggerExitEvent( Collider2D col )
	{

		isTouchingSurface = false;

	}


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		if( _controller.isGrounded )
			_velocity.y = 0;

		float normalizedHorizontalSpeed = CrossPlatformInputManager.GetAxis("Horizontal");

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

		/*
		if( CrossPlatformInputManager.GetButton( KeyCode.RightArrow ) )
		{
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );


		}
		else if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
		else
		{
			normalizedHorizontalSpeed = 0;
		}
		*/

		if (m_isJumping == GroundChecker.Direction.NONE) {
			if(m_GroundChecker.IsGrounded(GroundChecker.Direction.BOTTOM)) {
				m_Jump = 0;
				if(CrossPlatformInputManager.GetButtonDown("Jump")) {
					Debug.Log ("JumpUp");
					m_isJumping = GroundChecker.Direction.BOTTOM;
					m_Jump++;
				}
			} else if(m_GroundChecker.IsGrounded(GroundChecker.Direction.LEFT)) {
				m_Jump = 0;
				if(CrossPlatformInputManager.GetButtonDown("Jump")) {
					Debug.Log ("JumpLeft");
					m_isJumping = GroundChecker.Direction.LEFT;
					m_Jump++;
				}
			} else if(m_GroundChecker.IsGrounded(GroundChecker.Direction.RIGHT)) {
				m_Jump = 0;
				if(CrossPlatformInputManager.GetButtonDown("Jump")) {
					Debug.Log ("JumpRight");
					m_isJumping = GroundChecker.Direction.RIGHT;
					m_Jump++;
				}
			} else {
				//DoubleJump
				if(m_Jump < extraJumpCount) {
					if(CrossPlatformInputManager.GetButtonDown("Jump")) {
						Debug.Log ("MultiJump");
						m_isJumping = GroundChecker.Direction.BOTTOM;
						m_Jump++;
					}
				}
			}
		}


		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		//_runVelocity.x = Mathf.SmoothDamp( _runVelocity.x, normalizedHorizontalSpeed * runSpeed, ref _acceleration, smoothTime);
		_runVelocity.x = normalizedHorizontalSpeed * runSpeed;
		_velocity.x = _runVelocity.x;
		
		_wallJumpVelocity.x = Mathf.SmoothDamp(_wallJumpVelocity.x, 0, ref _wallJumpAcceleration, wallJumpTime);
		_velocity.x += _wallJumpVelocity.x;

		switch(m_isJumping) {
			case GroundChecker.Direction.TOP:
				//Jump off... the ceiling? No.
				break;
			case GroundChecker.Direction.BOTTOM:
				//Jump off the ground.
				Debug.Log ("JumpUpWall");
				_velocity += ((Vector3.up * jumpHeight));
				break;
			case GroundChecker.Direction.LEFT:
				//Jump off the left wall, to the right.
				Debug.Log ("JumpLeftWall");
				_wallJumpVelocity += ((Vector3.right * wallJumpSideSpeed));
				_velocity += ((Vector3.up * wallJumpUpSpeed));
				wallJumpLeftCooloffOn = true;
				break;
			case GroundChecker.Direction.RIGHT:
				//Jump off the right wall, to the left.
				Debug.Log ("JumpRightWall");
				_wallJumpVelocity += ((Vector3.left * wallJumpSideSpeed));
				_velocity += ((Vector3.up * wallJumpUpSpeed));
				wallJumpRightCooloffOn = true;
				break;
			case GroundChecker.Direction.NONE:
				//No jump.
				break;
		}


		m_isJumping = GroundChecker.Direction.NONE;

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		if(_velocity.x >= maxHorizontalSpeed)
			_velocity.x = maxHorizontalSpeed;
		if(_velocity.x <= -maxHorizontalSpeed)
			_velocity.x = -maxHorizontalSpeed;
		if(_velocity.y >= maxVerticalSpeed)
			_velocity.y = maxVerticalSpeed;
		if(_velocity.y <= -maxVerticalSpeed)
			_velocity.y = -maxVerticalSpeed;


		_controller.move( _velocity * Time.deltaTime );


		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
	}



}
