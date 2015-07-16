using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	public ParticleSystem playerDeathLavaParticles;
	Player currentPlayer;

	void Awake () {

		currentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	
	}
	
	void Update () {

		if(currentPlayer.HasPowerup(Powerup.Powerups.WalkOnLiquid)){

			this.GetComponent<BoxCollider2D>().isTrigger = false;

		} else {

			this.GetComponent<BoxCollider2D>().isTrigger = true;

		}
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.GetComponent<Player>() != null){
			
			other.GetComponent<Player>().Die();			
			ParticleSystem particle = Instantiate(playerDeathLavaParticles, other.transform.position, Quaternion.identity) as ParticleSystem;
			particle.transform.Rotate(-90, 0, 0);
			
		}
	}
}
