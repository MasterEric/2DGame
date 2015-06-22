using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	Prime31.CharacterController2D cc;

	// Use this for initialization
	void Start () {

		cc = GetComponent<Prime31.CharacterController2D>();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.D)){

			cc.move(new Vector3(0, 0.1f, 0));

		}
	
	}
}
