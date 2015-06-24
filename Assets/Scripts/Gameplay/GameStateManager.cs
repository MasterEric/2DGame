using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {
	static bool isDone = false;
	public static bool isInitialized = false;

	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		this.tag = "GameStateManager";
		//Initialize player preferences.
		//if(!PlayerPrefs.HasKey("ViewModelsEnabled"))
		//	PlayerPrefs.SetInt("ViewModelsEnabled", 1);
		if(!PlayerPrefs.HasKey("Volume"))
			PlayerPrefs.SetFloat("Volume", 100);
		//if(!PlayerPrefs.HasKey("FieldOfView"))
		//	PlayerPrefs.SetFloat("FieldOfView", 75);
		//if(!PlayerPrefs.HasKey("PlayerName"))
		//	PlayerPrefs.SetString("PlayerName", "Player");
		isInitialized = true;
	}
	void Update() {
		if(!isDone) {
			SceneChanger.GetSceneChanger().SetScene(SceneChanger.GetSceneChanger().StartingScene);
			KongregateManager.StartKongregateAPI();
			isDone = true;
		}
	}

}
