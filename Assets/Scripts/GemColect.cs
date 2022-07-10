using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemColect : MonoBehaviour {

	public AudioClip fxCollect;

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Player") ) {

			GameManager.instance.score+=10;
			SoundManager.instance.PlayfxGemCollect (fxCollect);
			Destroy (gameObject);

	}

	}

}
