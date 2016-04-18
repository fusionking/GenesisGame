using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider2D)
	{
		Debug.Log ("Object destroyed");
		Destroy (collider2D.gameObject);
		
		
		
	}
}
