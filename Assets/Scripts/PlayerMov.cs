using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour {

	public Rigidbody playermov;
	public float force;
	public float maxSpeed = 200.0f;
	public Transform l;
	public AudioClip jump;
	public AudioClip thump;

	private AudioSource source;
	private bool IsGrounded;
	private int x;


	// Use this for initialization
	void Start () {
		force = force*Time.deltaTime;
		Physics.gravity = new Vector3 (0.0f, -120.0f, 0.0f); //-85
		IsGrounded = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playermov.velocity.magnitude > maxSpeed) {
			playermov.velocity = playermov.velocity.normalized * maxSpeed;
		}

		if (Input.GetKey ("e"))
			{
			IsGrounded = true;
			Debug.Log ("Grounded");
			}

		if (force < 455)  //955
		{
			force = force+5;
		}	
		if (force > 475) //975
		{
			force = force-3;
		}	

		if (Input.GetKey ("d")) {
			playermov.AddForce (force*2.0f/4.0f, 0.0f, 0.0f);
		}
		if (Input.GetKey ("a")) {
			playermov.AddForce (-force*2.0f/4.0f, 0.0f, 0.0f);
		}
		if ((Input.GetKey ("space") || Input.GetKey ("w")) && IsGrounded == true) {

			playermov.AddForce (0.0f, force * 150.0f/10.0f, 0.0f);
			IsGrounded = false;
			AudioSource.PlayClipAtPoint (jump, transform.position);
		}
			

		if (IsGrounded == false) 
		{
			if (Input.GetKey ("a")) 
				{
				playermov.AddForce (force/6.0f, 0.0f, 0.0f);
				}
			if (Input.GetKey ("d")) 
				{
				playermov.AddForce (-force/6.0f, 0.0f, 0.0f);
				}
		}

	}

	void OnCollisionEnter (Collision info)
	{
		if (info.collider.tag == "jumpable") {
			Debug.Log ("Grounded");
			AudioSource.PlayClipAtPoint (thump, transform.position);
			IsGrounded = true;
		}
		if (info.collider.tag == "Death") {
			Debug.Log ("You Dieded");
			transform.position = new Vector3(-25.0f,4.0f,0.0f);
		}

	}
	void OnCollisionStay ()
	{
	playermov.AddForce (0.0f, -69.0f, 0.0f);
	}
}
