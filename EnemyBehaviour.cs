using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 60f;
	public GameObject projectile;
	public float Speed = 5f;
	public int scoreValue = 20;
	public AudioClip DeathSound;
	public AudioSource source;

	private ScoreKeeper scoreKeeper;

	public float shotsPerSeconds = 0.5f;

	void Start()
	{
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	void Update()
	{
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability){
			Fire ();
		}

	}

	void Fire()
	{
		Vector3 startPos = transform.position + new Vector3 (-1, 0, 0);
		GameObject missile = Instantiate (projectile, startPos, Quaternion.identity) as GameObject;
		
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2 (-Speed,0);

	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.tag == "Projectile") {
		
			Debug.Log ("Hit by projectile");
			health = health -20f;
			if(health <= 0f)
			{
			scoreKeeper.Score(scoreValue);
			Destroy (gameObject);
			source.clip = DeathSound;
			source.Play();
			}

		}


	}


}
