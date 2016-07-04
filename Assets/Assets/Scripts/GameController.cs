using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Transform enemy;

	[Header("Wave Properties")]
	public float timeBeforeSpawning = 1.5f;
	public float timeBetweenEnemies = 0.25f;
	public float timeBeforeWaves = 2.0f;

	public int enemiesPerWave = 10;
	private int currentNumberOfEnemies = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		yield return new WaitForSeconds (timeBeforeSpawning);

		while (true) {
			if (currentNumberOfEnemies <= 0) {
				for (int i = 0; i < enemiesPerWave; i++) {
					float randDistance = Random.Range (10, 25);

					Vector2 randDirection = Random.insideUnitCircle;
					Vector3 enemyPos = this.transform.position;

					enemyPos.x = randDirection.x * randDistance;
					enemyPos.y = randDirection.y * randDistance;

					Instantiate (enemy, enemyPos, this.transform.rotation);
					currentNumberOfEnemies++;
					yield return new WaitForSeconds (timeBetweenEnemies);
				}
			}

			yield return new WaitForSeconds (timeBeforeWaves);
		}
	}

	public void KilledEnemy(){
		currentNumberOfEnemies--;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
