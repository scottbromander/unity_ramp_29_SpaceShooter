using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int health = 2;

	void OnCollisionEnter2D(Collision2D theCollision){
		//Debug.Log ("Hit: " + theCollision.gameObject.name);

		if (theCollision.gameObject.name.Contains ("laser")) {
			LaserBehaviour laser = theCollision.gameObject.GetComponent ("LaserBehavior") as LaserBehaviour;
			health -= laser.damage;
			Destroy (theCollision.gameObject);
		}

		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
