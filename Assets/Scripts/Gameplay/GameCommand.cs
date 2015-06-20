using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;

public class GameCommand : MonoBehaviour {
	public void LoadScene(string SceneName) {
		if(SceneChanger.DoesSceneChangerExist()) {
			Debug.LogWarning("Setting scene to "+SceneName+"...");
			SceneChanger.GetSceneChanger().SetScene(SceneName);
		} else {
			Debug.LogError("Error: SceneChanger does not exist, could not load scene.");
		}
	}
	public void ExitGame(){
		Application.Quit();
	}
}
