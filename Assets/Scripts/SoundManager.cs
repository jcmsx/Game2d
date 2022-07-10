using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


	public static SoundManager instance;

	public AudioSource fxPlayer;
	public AudioSource fxGemCollect;


	void Awake() {
		if (instance == null) {

			instance = this;
		} else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);   // nao destroy musica.... continua
	
	
	}

	public void PlayfxPlayer(AudioClip clip) {
		fxPlayer.clip = clip;

		fxPlayer.Play ();

	}
	public void PlayfxGemCollect(AudioClip clip) {
		fxGemCollect.clip = clip;

		fxGemCollect.Play ();

	}
}
