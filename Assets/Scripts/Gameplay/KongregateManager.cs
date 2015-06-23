using UnityEngine;
using System.Collections;

public class KongregateManager : MonoBehaviour {
	//Instance management.
	private static bool isKongregate = false;	
	public static bool isInitialized {
		get { return isKongregate; }
	}
	void Start() {
		DontDestroyOnLoad(this.gameObject);
		this.tag = "KongregateManager";
		this.name = "KongregateManager";
	}

	//Player info
	static int userId = 0;
	public static int kongregateUserId {
		get { return userId; }
	}
	static string username = "Guest";
	public static string kongregateUsername {
		get { return username; }
	}
	static string gameAuthToken = "";
	public static string kongregateAuthToken {
		get { return gameAuthToken; }
	}
	
	static void RegisterKongregateHandlers() {
		Application.ExternalEval(
			"kongregate.services.addEventListener('login', function(){" +
			"	var services = kongregate.services;" +
			"	var params=[services.getUserId(), services.getUsername(), services.getGameAuthToken()].join('|');" +
			"	kongregateUnitySupport.getUnityObject().SendMessage('KongregateManager', 'OnKongregateUserSignedIn', params);" + 
			"});"
		);
	}

	//Start the Kongregate API.
	public static void StartKongregateAPI() {
		if(!isKongregate) {
			//Play a script in the web page.
			Application.ExternalEval(
				"if(typeof(kongregateUnitySupport) != 'undefined'){"+
				" kongregateUnitySupport.initAPI('KongregateManager', 'OnKongregateAPILoaded');" +
				"};"
			);
		}
	}

	//Statistic names are case sensitive!
	//To report to the Kongregate API that a badge or achievement has been completed, submit a score with a value of 1.
	public static void SubmitStatistic(string scoreName, int scoreValue) {
		if(isKongregate)
			Application.ExternalCall("kongregate.stats.submit",scoreName,scoreValue);
	}

	//Called when the Kongregate API is loaded.
	void OnKongregateAPILoaded(string userInfoString) {
		// We now know we're on Kongregate
		isKongregate = true;
	
		string[] input = userInfoString.Split("|"[0]);
		userId = int.Parse(input[0]);
		username = input[1];
		gameAuthToken = input[2];
	}
	// Called when the Kongregate user signs in.
	void OnKongregateUserSignedIn(string userInfoString) {
		string[] input = userInfoString.Split("|"[0]);
		userId = int.Parse(input[0]);
		username = input[1];
		gameAuthToken = input[2];
	}
}
