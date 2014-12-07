using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

	public GameObject noShootEnemyPrefab;
	public GameObject shootingEnemyPrefab;

	int wave1Time = 5;
	int wave1Enemies = 6;
	int wave2Time = 15;
	int wave2Enemies = 6;
	int wave3Time = 30;
	int wave3Enemies = 12;
	int wave4Time = 45;
	int wave4Enemies = 12;
	int wave5Time = 60;
	int wave5Enemies = 24;

	bool spawning = false;
	float waveSpawn = 0;
	float gameTime = 0;

	public float enemySpawnRate = 5;
	float enemySpawnTime = 0;
	float spawnDistance = 10;

	void Update () {
		// Check whether or not enemies need to be spawned
		if (!spawning) {
			gameTime += Time.deltaTime;
			if(gameTime >= wave1Time) {
				if(gameTime >= wave2Time) {
					if(gameTime >= wave3Time) {
						if(gameTime >= wave4Time) {
							if(gameTime >= wave5Time) {
								SpawnWave5(noShootEnemyPrefab);
							}
							else {
								SpawnWave4(noShootEnemyPrefab);
							}
						}
						else {
							SpawnWave3(noShootEnemyPrefab);
						}
					}
					else {
						SpawnWave2(noShootEnemyPrefab);
					}
				}
				else {
					SpawnWave1 (noShootEnemyPrefab);
				}
			}
		}

		else {
			gameTime += Time.deltaTime;
			if(waveSpawn == 1 && gameTime + Time.deltaTime >= wave2Time)
				spawning = false;
			else if(waveSpawn == 2 && gameTime + Time.deltaTime >= wave3Time)
				spawning = false;
			else if(waveSpawn == 3 && gameTime + Time.deltaTime >= wave4Time)
				spawning = false;

			enemySpawnTime += Time.deltaTime;
			if(enemySpawnTime >= enemySpawnRate) {
				enemySpawnTime = 0;
				if(enemySpawnRate >= 1)
					enemySpawnRate *= 0.95f;
				Vector3 offset = Random.onUnitSphere;
				offset.z = 0;
				offset = offset.normalized * spawnDistance;
				Instantiate (shootingEnemyPrefab, transform.position + offset, Quaternion.identity);
			}
		}
	}

	void SpawnWave1 (GameObject enemyPrefab) {
		spawning = true;
		waveSpawn = 1;
		// Spawns the enemies at the top of the screen, facing down.
		for (int enemiesSpawned = 0; enemiesSpawned < wave1Enemies; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-5 + enemiesSpawned, 4.5f, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 180));
		}
	}

	void SpawnWave2 (GameObject enemyPrefab) {
		spawning = true;
		waveSpawn = 2;
		// Spawns the enemies at the bottom of the screen, facing up.
		for (int enemiesSpawned = 0; enemiesSpawned < wave2Enemies; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-5 + enemiesSpawned, -4.5f, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 0));
		}
	}

	void SpawnWave3 (GameObject enemyPrefab) {
		spawning = true;
		waveSpawn = 3;
		// Spawns the enemies at the top and bottom of the screen, facing down and up, respectively.
		for (int enemiesSpawned = 0; enemiesSpawned < wave3Enemies / 2; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-5 + enemiesSpawned, 4.5f, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 180));
		}
		for (int enemiesSpawned = 0; enemiesSpawned < wave3Enemies / 2; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-5 + enemiesSpawned, -4.5f, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 0));
		}
	}

	void SpawnWave4 (GameObject enemyPrefab) {
		spawning = true;
		waveSpawn = 4;
		// Spawns the enemies at the left and right of the screen, facing right and left, respectively.
		for (int enemiesSpawned = 0; enemiesSpawned < wave4Enemies / 2; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-4.5f, -5 + enemiesSpawned, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, -90));
		}
		for (int enemiesSpawned = 0; enemiesSpawned < wave4Enemies / 2; enemiesSpawned++) {
			Vector3 pos = new Vector3 (4.5f, -5 + enemiesSpawned, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 90));
		}
	}

	void SpawnWave5 (GameObject enemyPrefab) {
		spawning = true;
		waveSpawn = 4;
		// Spawns the enemies all around the screen, facing in.
		for (int enemiesSpawned = 0; enemiesSpawned < wave5Enemies / 4; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-5 + enemiesSpawned, 4.5f, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 180));
		}
		for (int enemiesSpawned = 0; enemiesSpawned < wave5Enemies / 4; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-5 + enemiesSpawned, -4.5f, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 0));
		}
		for (int enemiesSpawned = 0; enemiesSpawned < wave5Enemies / 4; enemiesSpawned++) {
			Vector3 pos = new Vector3 (-4.5f, -5 + enemiesSpawned, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, -90));
		}
		for (int enemiesSpawned = 0; enemiesSpawned < wave5Enemies / 4; enemiesSpawned++) {
			Vector3 pos = new Vector3 (4.5f, -5 + enemiesSpawned, 0);
			Instantiate (enemyPrefab, pos, Quaternion.Euler (0, 0, 90));
		}
	}
}
