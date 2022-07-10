using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public int jumpForce;

	public Transform groundCheck;
	public LayerMask layerGround;
	public float gradiusCheck;

	public bool grounded;
	private bool jumping;
	private bool facingRight = true;
	private bool isAlive = true;
	private bool levelCompleted = false;
	private bool timeIsOver = false;

	private Rigidbody2D rb2D;
	private Animator anim;




	// Use this for initialization
	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, layerGround);

		if (Input.GetButtonDown ("Jump") && grounded) {


			jumping = true;

		}

		if ((int)GameManager.instance.time <= 0 && !timeIsOver) {

			timeIsOver = true;
			PlayerDie ();
		}

		PlayAnimations ();
	
	}

	void FixedUpdate(){


		if (isAlive && !levelCompleted) {

			float move = Input.GetAxis ("Horizontal");

			rb2D.velocity = new Vector2 (move * speed, rb2D.velocity.y);

			if ((move < 0 && facingRight) || (move > 0 && !facingRight)) {
				Flip ();
			}

			if (jumping) {

				rb2D.AddForce (new Vector2 (0f, jumpForce));
				jumping = false;
			}

		} 


		else
		
		{
			
			rb2D.velocity = new Vector2 (0, rb2D.velocity.y);
		}

	}
		

			

	void PlayAnimations(){

		if (levelCompleted) {
			anim.Play ("Celebrate");

		} 

		else if (!isAlive) {

			anim.Play ("Die");
		}


		else if (grounded && rb2D.velocity.x != 0) {
			anim.Play ("Run");

		}
		else if (grounded && rb2D.velocity.x == 0){
			anim.Play ("Idle");
	} 

	else if (!grounded) {
		anim.Play ("Jump");
		}
	}

	void Flip(){

		facingRight = !facingRight;
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

		}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.CompareTag ("Enemy")) {
			PlayerDie ();
		
			}

		}

	void PlayerDie(){

		isAlive = false;
		Physics2D.IgnoreLayerCollision (9, 10);

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.CompareTag ("Exit")) {
			levelCompleted = true;

		}

	}

	void DieAnimationFinished(){

		if (timeIsOver)
			GameManager.instance.SetOverlay (GameManager.GameStatus.LOSE);
		else
			GameManager.instance.SetOverlay (GameManager.GameStatus.DIE);
		

	}


	void CelebrateAnimationFinished(){
		GameManager.instance.SetOverlay (GameManager.GameStatus.WIN);

	}



}

