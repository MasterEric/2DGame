using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip deathSound;
	public GameObject gameOverUI;
	public GameObject gameHUD;

	public Powerup.Powerups[] currentPowerups = new Powerup.Powerups[4];

	void Start () {

		gameOverUI.SetActive(false);
	
	}
	
	public void Die(){

		this.gameObject.SetActive(false);
		gameOverUI.SetActive(true);
		gameHUD.SetActive(false);

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
