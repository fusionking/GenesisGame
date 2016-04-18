using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	private HealthKeeper healthKeeper;
	private float damage = 40f;
	// Use this for initialization
	void Start () {
	
		health = 500f;
		healthKeeper = GameObject.Find ("Health").GetComponent<HealthKeeper> ();
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.tag == "EnemyLaser") {
			
			Debug.Log ("Hit by laser");
			health = health - 40f;
			healthKeeper.DecreaseHealth(damage);
			if(health <= 0f)
			{


				Application.LoadLevel ("Death");

			}
			
		}
		
		
	}
}
