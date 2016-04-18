using UnityEngine;
using System.Collections;

public class PlayerBulletController : MonoBehaviour
{
     public GameObject playerObject = null; // Will be populated automatically when the bullet is created in PlayerStateListener
     public float bulletSpeed = 15.0f;
	 Rigidbody2D MyR;
	 public AudioClip DeathSound;
	public AudioSource source;
	public int score = 0;

	
	 private float selfDestructTimer = 0.0f;
    
	void Update()
	{
		if(selfDestructTimer > 0.0f)
		{
			if(selfDestructTimer < Time.time)
				Destroy(gameObject);
		}
	}
	
     public void launchBullet()
     {
          // The local scale of the player object tells us which direction
          // the player is looking. Rather than programming in extra variables to
          // store where the player is looking, just check what already knows
          // that information... the object scale!
          float mainXScale = playerObject.transform.localScale.x;

		  Vector2 bulletForce;
		
          if(mainXScale < 0.0f)
          {
               // Fire bullet left
               bulletForce = new Vector2(bulletSpeed * -1.0f,0.0f);
          }
          else
          {
               // Fire bullet right
               bulletForce = new Vector2(bulletSpeed,0.0f);
          }
		MyR = GetComponent<Rigidbody2D>();
		MyR.velocity = bulletForce;
		
		selfDestructTimer = Time.time + 1.0f;
     }




	void OnTriggerEnter2D (Collider2D collider2D)
	{
		/*if (collider2D.tag == "Enemy") {
		
			Debug.Log ("Collided");
			score = score + 20;
			playerObject.GetComponent<PlayerStateListener>().ScoreKeeper.text = "Score: " + score + "";
			Destroy (collider2D.gameObject);
			source.clip = DeathSound;
			source.Play();
	
		} *///else if (collider2D.tag == "Level2") {
		
		//Application.LoadLevel ("Level2");
		
		
		
	}


}
