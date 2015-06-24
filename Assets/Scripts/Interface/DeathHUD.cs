using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathHUD : MonoBehaviour {
	public Text scoreText;
	public Text highscoreText;
	
	void Start() {
		this.tag = "DeathHUD";
	}
	public static bool DoesDeathHUDExist() {
		return GameObject.FindGameObjectWithTag("DeathHUD") != null;
	}
	public static DeathHUD GetDeathHUD() {
		return GameObject.FindGameObjectWithTag("DeathHUD").GetComponent<DeathHUD>();
	}
	
	public void SetScore (int score) {
		scoreText.text = score.ToString();
	}
	public void SetHighscore (int highscore) {
		highscoreText.text = highscore.ToString();
	}
}
