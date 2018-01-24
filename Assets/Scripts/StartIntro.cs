using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartIntro : MonoBehaviour {

	public GameObject cube01;
	public GameObject cube02;
	public GameObject boundary01;
	public GameObject playerintro;
	public GameObject cameraintro;
	public GameObject realcameraintro;
	public GameObject platform01;
	public GameObject cube01vis;
	public GameObject static01;


	public AudioClip Appear;
	public AudioClip Thump;
	public AudioClip Scribble;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0.0f, -125.0f, 0.0f);
		StartCoroutine (IntroAnim ());
	}

	IEnumerator IntroAnim()
	{
		boundary01.SetActive (false);
		cube01vis.SetActive (false);
		cube01.SetActive (false);
		cube02.SetActive (false);
		platform01.SetActive (false);
		yield return new WaitForSecondsRealtime(1.0f);
		AudioSource.PlayClipAtPoint (Appear, transform.position);
		cube01.SetActive (true);
		cube02.SetActive (true);
		yield return new WaitForSecondsRealtime(1.5f);
		AudioSource.PlayClipAtPoint (Appear, transform.position);
		//yield return new WaitForSecondsRealtime(0.1f);
		boundary01.SetActive (true);
		cube01vis.SetActive (true);
		yield return new WaitForSecondsRealtime(1.25f);
		playerintro.SetActive (true);
		AudioSource.PlayClipAtPoint (Appear, transform.position);
		cameraintro.SetActive (false);
		realcameraintro.SetActive (true);
		yield return new WaitForSecondsRealtime(1.25f);
		platform01.transform.position = new Vector3(-4.0f, 7.0f, 0.0f);
		platform01.SetActive (true);


	}

	// Update is called once per frame
	void FixedUpdate () {

		if (playerintro.transform.position.x >= -9 && playerintro.transform.position.x <= 0.5)
		{
			playerintro.transform.parent = platform01.transform;
		} 

		if (playerintro.transform.position.x >= 0.5f || playerintro.transform.position.x <= -9)
		{
			playerintro.transform.parent = static01.transform;
		} 

		if (playerintro.transform.position.x >= 95.3)
		{
		Debug.Log ("FIM");
		SceneManager.LoadScene ("Scene 02");

		} 
	}
}
