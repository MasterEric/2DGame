using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip deathSound;

	public Powerup.Powerups[] currentPowerups = new Powerup.Powerups[4];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die(){

		this.gameObject.SetActive(false);

	}

	public void AddPowerup(Powerup.Powerups powerupToAdd){

		Debug.Log ("Collected powerup of type " + powerupToAdd.ToString() + ".");

	}

	public bool HasPowerup(Powerup.Powerups powerupToCheck){

		foreach(Powerup.Powerups p in currentPowerups){

			if(p == powerupToCheck){

				return true;

			} else {

				return false;

			}
		}

		return false;

	}
}
