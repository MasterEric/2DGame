using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	private Powerups powerupType;

	public enum Powerups{
		
		DoubleJump = 0,
		TripleJump = 1,
		QuadrupleJump = 2,
		LightArmor = 3,
		MediumArmor = 4,
		HeavyArmor = 5,
		PlasmaShield = 6,
		WalkOnLiquid = 7,
		Speedup2X = 8,
		Speedup3X = 9,
		Autopilot = 10
		
	}

	void FixedUpdate () {
	
		//Do $wag Spr!t$ $t|_|FF H$RE

	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.GetComponent<Player>() != null){

			col.gameObject.GetComponent<Player>().AddPowerup(powerupType);
			Destroy (this.gameObject);

		}

	}

	public void SetPowerUpType(Powerups powerupTypeToSet){

		this.powerupType = powerupTypeToSet;

	}
}
