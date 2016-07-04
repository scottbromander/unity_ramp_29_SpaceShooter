using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int health = 2;
	public Transform explosion;

	void OnCollisionEnter2D(Collision2D theCollision){
		

		if (theCollision.gameObject.name.Contains("laser")) {
			LaserBehaviour laser = theCollision.gameObject.GetComponent ("LaserBehaviour") as LaserBehaviour;
			health -= laser.damage;
			print ("Health: " + health);
			Destroy (theCollision.gameObject);
		}

		if (health <= 0) {

			if (explosion) {
				GameObject exploder = ((Transform)Instantiate (explosion, this.transform.position, this.transform.rotation)).gameObject;
				Destroy (exploder, 2.0f);
			}

			Destroy (this.gameObject);
			GameController controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
			controller.KilledEnemy ();


		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
