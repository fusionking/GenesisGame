using UnityEngine;
using System.Collections;

public class bossBehaviour : MonoBehaviour {

	public float health = 100f;
	public GameObject projectile;
	public float Speed = 3f;
	Animator enemyAnim;

	public int scoreValue = 100;
	
	private ScoreKeeper scoreKeeper;
	
	void Start()
	{
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
		enemyAnim = GetComponent<Animator> ();
	}


	void Update()
	{
		/*Vector3 startPos = transform.position + new Vector3 (1, 0, 0);
		GameObject missile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2 (-Speed,0);*/
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("Hittta");

		if (col.tag == "Projectile") {
			
			Debug.Log ("Hit by projectile");
			health = health -10f;
			if(health <= 0f)
			{
				scoreKeeper.Score(scoreValue);
				Destroy (gameObject);
				enemyAnim.SetTrigger ("Death");
				Wait (3);  
				Application.LoadLevel("Win");
			}
			
		}

		
	}

	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		Debug.Log("Start Wait() function. The time is: "+Time.time);
		Debug.Log( "Float duration = "+duration);
		yield return new WaitForSeconds(duration);   //Wait
		Debug.Log("End Wait() function and the time is: "+Time.time);
	}
}
