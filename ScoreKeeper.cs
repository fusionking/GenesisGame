using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public int score;
	private Text myText;

	void Start()
	{
		myText = GetComponent<Text> ();
		//Reset ();
	}
	public void Score(int points)
	{
		score += points;
		myText.text = "Score: " + score.ToString ();
	}
	// Use this for initialization
	public void Reset () {
	
		score = 0;
		myText.text = "Score: " + score.ToString ();
	}
	

}
