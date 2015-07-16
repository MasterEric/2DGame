using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	Player player;
	public int currentScore = 0;

	const int scoreOnLevelChange = 100;
	const int scoreOnShieldCollect = 50;
	const int scoreOnScoreUpCollect = 500;
	//Attach this to the player class.
	void Start () {
    	this.tag = "ScoreManager";
        currentScore = 0;
		player = GetComponent<Player>();
	}
    public static bool DoesScoreManagerExist() {
		return GameObject.FindGameObjectWithTag("ScoreManager") != null;
	}
	public static ScoreManager GetScoreManager() {
		return GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
	}
    void Update () {
    	if(GameHUD.DoesGameHUDExist()) {
            GameHUD.GetGameHUD().SetScore(currentScore)
        }
       	if(DeathHUD.DoesDeathHUDExist()) {
            DeathHUDGetDeathHUD().SetScore(currentScore)
        }
    }
	public static int GetCurrentScore() {
		return GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().currentScore;
	}
	public void ChangeLevel() {
		currentScore += scoreOnLevelChange;
	}
}
