using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip deathSound;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die(){

		GetComponent<AudioSource>().clip = deathSound;

	}

	public void AddPowerup(Powerup.Powerups powerupToAdd){

		Debug.Log ("Collected powerup of type " + powerupToAdd.ToString() + ".");

	}
}
