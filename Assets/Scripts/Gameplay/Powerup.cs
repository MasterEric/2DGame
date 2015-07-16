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
		WalkOnLiquid = 6,
		Speedup2X = 7,
		Speedup3X = 8,
		Autopilot = 9
		
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
