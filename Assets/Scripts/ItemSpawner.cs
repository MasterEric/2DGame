using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	public Powerup.Powerups[] possibleSpawns = new Powerup.Powerups[4];
	public Powerup powerupPrefab;


	// Use this for initialization
	void Start () {

		int puToSpawn = Random.Range(0, possibleSpawns.Length);

		Powerup p = Instantiate(powerupPrefab, this.transform.position, Quaternion.identity) as Powerup;
		p.SetPowerUpType(possibleSpawns[puToSpawn]);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
