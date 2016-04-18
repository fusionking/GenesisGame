using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthKeeper : MonoBehaviour {

	public float health;
	private Text myText;
	
	void Start()
	{
		myText = GetComponent<Text> ();
		//Reset ();
	}
	public void DecreaseHealth(float damage)
	{
		health = health - damage;
		myText.text = "Health: " + health.ToString ();
	}
	// Use this for initialization
	public void Reset () {
		
		health = 2000f;
		myText.text = "Health: " + health.ToString ();
	}
}
