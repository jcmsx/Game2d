using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Sprite[] overlaySprites;
	public Image overlay;
	public Text timeHud;
	public Text scoreHud;

	public float time;
	public int score;

	public enum GameStatus { WIN, LOSE,	DIE, PLAY	}
	public GameStatus status;


	void Awake (){

		if (instance == null) {

			instance = this;
		} else {
			Destroy (gameObject);
		}

	}
	



	// Use this for initialization
	void Start () {

		time = 30f;

		score = 0;

		status = GameStatus.PLAY;

	}
	
	// Update is called once per frame
	void Update () {

		if (status == GameStatus.PLAY) {

			time -= Time.deltaTime;

			int timeInt = (int)time;

			if (timeInt >= 0) {

				timeHud.text = "Time: " + timeInt.ToString ();
				scoreHud.text = "Score: " + score.ToString ();

			}


		} else if (status == GameStatus.WIN) {

			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);


		} else {
			
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}
}

}

