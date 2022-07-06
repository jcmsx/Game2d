﻿using System.Collections;
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
	
	}

	void FixedUpdate(){

		float move = 0f;

		move = Input.GetAxis ("Horizontal");

		rb2D.velocity = new Vector2 (move * speed, rb2D.velocity.y);

		if ((move < 0 && facingRight) || (move > 0 && !facingRight)){
			Flip();
	}

		if (jumping) {

			rb2D.AddForce (new Vector2 (0f, jumpForce));
			jumping = false;

		}
		PlayAnimations ();

		}

	void PlayAnimations(){

		if (grounded && rb2D.velocity.x != 0) {
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
}

