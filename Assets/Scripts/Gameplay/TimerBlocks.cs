using UnityEngine;
using System.Collections;

public class TimerBlocks : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {

		StartCoroutine(Flash ());

	}

	IEnumerator Flash() {

		this.GetComponent<Renderer>().material.color = Color.red;

		yield return new WaitForSeconds(0.25f);

		this.GetComponent<Renderer>().material.color = Color.white;

		yield return new WaitForSeconds(0.25f);

		this.GetComponent<Renderer>().material.color = Color.red;

		yield return new WaitForSeconds(0.25f);

		this.GetComponent<Renderer>().material.color = Color.white;

		yield return new WaitForSeconds(0.25f);

		this.GetComponent<Renderer>().material.color = Color.red;

		yield return new WaitForSeconds(0.25f);
		
		this.GetComponent<Renderer>().material.color = Color.white;
		
		yield return new WaitForSeconds(0.25f);
		
		this.GetComponent<Renderer>().material.color = Color.red;
		
		yield return new WaitForSeconds(0.25f);
		
		this.GetComponent<Renderer>().material.color = Color.white;
		
		yield return new WaitForSeconds(0.25f);
		
		this.GetComponent<Renderer>().material.color = Color.red;

		DestroyThis();

	}

	void DestroyThis(){

		Destroy(this.gameObject);

	}

}
