using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	Player player;
	public int currentScore;

	const int scoreOnLevelChange = 100;
	const int scoreOnShieldCollect = 50;
	const int scoreOnScoreUpCollect = 500;
	//Attach this to the player class.
	void Start () {
		player = GetComponent<Player>();
	}
	public static int GetCurrentScore() {
		return GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().currentScore;
	}
	public void ChangeLevel() {
		currentScore += scoreOnLevelChange;
	}
	public void CollectPowerUp() {
		currentScore += 
	}
}
