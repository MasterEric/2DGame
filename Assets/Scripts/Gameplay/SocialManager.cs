using UnityEngine;
using System.Collections;

public class SocialManager : MonoBehaviour {
	//Instance management.
	private static bool isKongregate = false;	
	public static bool isInitialized {
		get { return isKongregate; }
	}
	void Start() {
		DontDestroyOnLoad(this.gameObject);
		this.tag = "SocialManager";
		this.name = "SocialManager";
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
	
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";

    public void ShareScoreToTwitter (int score) {
        ShareToTwitter("I just scored "+score+"points in Gamename!");
    }

    public void ShareToTwitter (string textToDisplay) {
        Application.OpenURL(TWITTER_ADDRESS +
            "?text=" + WWW.EscapeURL(textToDisplay) +
            "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }
    
    //TODO: Replace with a legitimate App ID.
    private const string FACEBOOK_APP_ID = "123456789000";
    private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
 
    public void ShareScoreToFacebook(int score) {
        string link;
        string name = "Check out Gamename!";
        string caption = "Try out this endless platformer now!";
        string description = "I just scored "+score+"points in Gamename!";
        string picture;
        string redirect = "http://www.facebook.com";
        ShareToFacebook (link, name, caption, description, picture, redirect)
    }
 
    public void ShareToFacebook (string link, string name, string caption, string description, string picture, string redirect) {
        Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
            "&link=" + WWW.EscapeURL(link) +
            "&name=" + WWW.EscapeURL(name) +
            "&caption=" + WWW.EscapeURL(caption) + 
            "&description=" + WWW.EscapeURL(description) + 
            "&picture=" + WWW.EscapeURL(picture) + 
            "&redirect_uri=" + WWW.EscapeURL(redirect));
}
    
	static void RegisterKongregateHandlers() {
		Application.ExternalEval(
			"kongregate.services.addEventListener('login', function(){" +
			"	var services = kongregate.services;" +
			"	var params=[services.getUserId(), services.getUsername(), services.getGameAuthToken()].join('|');" +
			"	kongregateUnitySupport.getUnityObject().SendMessage('SocialManager', 'OnKongregateUserSignedIn', params);" + 
			"});"
		);
	}

	//Start the Kongregate API.
	public static void StartKongregateAPI() {
		if(!isKongregate) {
			//Play a script in the web page.
			Application.ExternalEval(
				"if(typeof(kongregateUnitySupport) != 'undefined'){"+
				" kongregateUnitySupport.initAPI('SocialManager', 'OnKongregateAPILoaded');" +
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
