using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public ParticleSystem playerDeathSpikeParticles;

	void OnTriggerEnter2D(Collider2D other) {

		if(other.GetComponent<Player>() != null){
		
			other.GetComponent<Player>().Die();			
			Instantiate(playerDeathSpikeParticles, other.transform.position, Quaternion.identity);


		}
	}
}
