using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	private bool movingRight = true;
	public float speed = 5f;
	private float xmax;
	private float xmin;


	// Use this for initialization
	void Start () {


			GameObject enemy = Instantiate (enemyPrefab, new Vector3 (3.3f, -5f, 0), Quaternion.identity) as GameObject;
			enemy.transform.parent = transform;


			/*float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
			Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (-0.5f, -2, distanceToCamera));
			Vector3 rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, -2, distanceToCamera));
			xmax = rightEdge.x;
			xmin = leftEdge.x;*/

		
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
	}

	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0);
		} else {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0);
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if (leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax) {
		
			movingRight = !movingRight;
		
		
		}

	}
}
