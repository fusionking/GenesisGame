using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadLevel (string name) {
		Application.LoadLevel (name);
	
	}
	
	// Update is called once per frame
	public void QuitRequest () {
		Application.Quit ();
	}
}
