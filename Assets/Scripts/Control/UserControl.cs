using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (Rigidbody2D), typeof(GroundChecker), typeof(CharacterMotor))]
public class UserControl : MonoBehaviour {
	CharacterMotor m_Character;
	GroundChecker m_GroundChecker;
	
	public int extraJumpCount = 1;	
	int m_Jump = 0;
	GroundChecker.Direction m_isJumping = GroundChecker.Direction.NONE;	
	
	void Awake() {
		m_Character = GetComponent<CharacterMotor>();
		m_GroundChecker = GetComponent<GroundChecker>();
	}
	
	void Update() {
		if (m_isJumping == GroundChecker.Direction.NONE) {
			if(m_GroundChecker.IsGrounded(GroundChecker.Direction.BOTTOM)) {
				m_Jump = 0;
				if(CrossPlatformInputManager.GetButtonDown("Jump")) {
					m_isJumping = GroundChecker.Direction.BOTTOM;
					m_Jump++;
				}
			} else if(m_GroundChecker.IsGrounded(GroundChecker.Direction.LEFT)) {
				m_Jump = 0;
				if(CrossPlatformInputManager.GetButtonDown("Jump")) {
					m_isJumping = GroundChecker.Direction.LEFT;
					m_Jump++;
				}
			} else if(m_GroundChecker.IsGrounded(GroundChecker.Direction.RIGHT)) {
				m_Jump = 0;
				if(CrossPlatformInputManager.GetButtonDown("Jump")) {
					m_isJumping = GroundChecker.Direction.RIGHT;
					m_Jump++;
				}
			} else {
				//DoubleJump
				if(m_Jump < extraJumpCount) {
					if(CrossPlatformInputManager.GetButtonDown("Jump")) {
						m_isJumping = GroundChecker.Direction.BOTTOM;
						m_Jump++;
					}
				}
			}
		}
	}
	
	void FixedUpdate() {
		//Use FixedUpdate since it updates at a fixed rate, meaning we don't need Time.deltaTime.
		//Read the inputs. Right = 1 Left = -1
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		//Pass parameters into the CharacterMotor.
		m_Character.Move(horizontal, m_isJumping);
		//Reset jump afterward
		m_isJumping = GroundChecker.Direction.NONE;
	}
}
