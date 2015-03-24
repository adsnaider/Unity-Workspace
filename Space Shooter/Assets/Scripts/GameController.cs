using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText RestartText;
	public GUIText GameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	void Start(){
		gameOver = false;
		restart = false;
		RestartText.text = "";
		GameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(!gameOver){
			yield return new WaitForSeconds(waveWait);
			for (int i=0; i<hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotations = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotations);
				yield return new WaitForSeconds(spawnWait);
			}
		}
		RestartText.text="Press 'R' to restart";
		restart = true;
	}
	void UpdateScore(){
		scoreText.text = "Score: "+score;
	}
	public void AddScore(){
		score +=10;
		UpdateScore ();
	}
	public void GameOver(){
		GameOverText.text="Game Over";
		gameOver = true;
	}
}
