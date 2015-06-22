using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public ParticleSystem playerDeathSpikeParticles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.GetComponent<Player>() != null){

		Destroy(other.attachedRigidbody);
		Instantiate(playerDeathSpikeParticles, other.transform.position, Quaternion.identity);
		other.GetComponent<Player>().Die();

		}
	}
}
