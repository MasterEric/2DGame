using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHUD : MonoBehaviour {
	public Text scoreText;
	public Text highscoreText;

	public enum Armor {
		none,
		armorHeavyFull,
		armorHeavyTwoThirds,
		armorHeavyOneThird,
		armorMediumFull,
		armorMediumHalf,
		armorLightFull
	}

	public enum Jump {
		none,
		jumpDouble,
		jumpTriple,
		jumpQuadruple
	}

	public Image armorHeavyFull;
	public Image armorHeavyTwoThirds;
	public Image armorHeavyOneThird;
	public Image armorMediumFull;
	public Image armorMediumHalf;
	public Image armorLightFull;

	public Image jumpDouble;
	public Image jumpTriple;
	public Image jumpQuadruple;

	public Image waterWalking;
	void Start() {
		this.tag = "GameHUD";
	}
	public static bool DoesGameHUDExist() {
		return GameObject.FindGameObjectWithTag("GameHUD") != null;
	}
	public static GameHUD GetGameHUD() {
		return GameObject.FindGameObjectWithTag("GameHUD").GetComponent<GameHUD>();
	}

	public void SetScore (int score) {
		scoreText.text = score.ToString();
	}
	public void SetHighscore (int highscore) {
		highscoreText.text = highscore.ToString();
	}
	public void SetArmor (Armor armor) {
		armorHeavyFull.enabled = false;
		armorHeavyTwoThirds.enabled = false;
		armorHeavyOneThird.enabled = false;
		armorMediumFull.enabled = false;
		armorMediumHalf.enabled = false;
		armorLightFull.enabled = false;
		switch(armor) {
			case Armor.armorHeavyFull:
				armorHeavyFull.enabled = true;
				break;
			case Armor.armorHeavyTwoThirds:
				armorHeavyTwoThirds.enabled = true;
				break;
			case Armor.armorHeavyOneThird:
				armorHeavyOneThird.enabled = true;
				break;
			case Armor.armorMediumFull:
				armorMediumFull.enabled = true;
				break;
			case Armor.armorMediumHalf:
				armorMediumHalf.enabled = true;
				break;
			case Armor.armorLightFull:
				armorLightFull.enabled = true;
				break;
		}

	}
	public void SetJump (Jump jump) {
		jumpDouble.enabled = false;
		jumpTriple.enabled = false;
		jumpQuadruple.enabled = false;
		switch(jump) {
			case Jump.jumpDouble:
				jumpDouble.enabled = true;
				break;
			case Jump.jumpTriple:
				jumpTriple.enabled = true;
				break;
			case Jump.jumpQuadruple:
				jumpQuadruple.enabled = true;
				break;
		}
	}
	public void SetWater (bool enabled) {
		waterWalking.enabled = enabled;
	}
}
