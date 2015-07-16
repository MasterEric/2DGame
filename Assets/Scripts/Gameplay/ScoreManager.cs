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
	}
    public static bool DoesScoreManagerExist() {
		return GameObject.FindGameObjectWithTag("ScoreManager") != null;
	}
	public static ScoreManager GetScoreManager() {
		return GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
	}
    void Update () {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0)
        if(GameHUD.DoesGameHUDExist()) {
            GameHUD.GetGameHUD().SetScore(currentScore)
            GameHUD.GetGameHUD().SetHighScore(currentHighScore)
        }
       	if(DeathHUD.DoesDeathHUDExist()) {
            DeathHUDGetDeathHUD().SetScore(currentScore)
            GameHUD.GetGameHUD().SetHighScore(currentHighScore)
        }

    }
	public int GetCurrentScore() {
		return currentScore;
	}
    public int GetHighScore() {
        return currentHighScore;
    }
	public void ChangeLevel() {
		currentScore += scoreOnLevelChange;
	}
    public void CheckHighScore() {
        if(currentScore >= currentHighScore) {
            PlayerPrefs.SetInt("HighScore", currentScore)
        }
    }
}
