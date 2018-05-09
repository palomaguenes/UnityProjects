using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawmWave;
	public float starWait;
	public float waveWait;

	public Text scoreText;
	private int score;
	private int count;

	public Text result;
	public Text restartText;

	private bool restart;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
		score = 0;

		result.enabled = false;
		restart = false;
		restartText.text = "";

	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}


	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (starWait);
		while (true) {
			
			for (int i = 0; i < hazardCount; i++) {
					
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; 
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawmWave);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore();
		ShowResult (true);
	}
	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void ShowResult(bool win){
		if ((score >= 100) && (win)){
			result.text = "You win";
		} else if (!win){
			result.text = "Game Over";
			restart = true;
			restartText.text = "Press R for restart";
		}
		result.enabled = true;
	}
}
