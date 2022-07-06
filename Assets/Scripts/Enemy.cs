using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	public float speed;
	public Transform groundCheck;
	public LayerMask layerGround;
	public float gradiusCheck;
	public bool grounded;

	private bool facingRight = true;
	private Rigidbody2D rb2D;
	private Animator anim;
	private bool isVisible = false;






	// Use this for initialization
	void Start () {

		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, 0.2f, layerGround);

		if (!grounded)
			Flip ();
		

	}

	void FixedUpdate(){

		if (isVisible)
			rb2D.velocity = new Vector2 (speed, rb2D.velocity.y);
		else
			rb2D.velocity = new Vector2 (0f, rb2D.velocity.y);
	}

	void Flip(){

		facingRight = !facingRight;
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		speed *= -1; 
	}

	void OnBecameVisible() {
		Invoke ("MoveEnemy", 3f);

	}

	void OnBecameInvisible() {
		Invoke ("StopEnemy", 3f);

	}

	void MoveEnemy(){
		isVisible = true;
		anim.Play ("Run");
	}

	void StopEnemy(){
		isVisible = false;
		anim.Play ("Idle");
	}



}
