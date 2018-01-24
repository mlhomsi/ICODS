using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	public GameObject Space2Start;
	public GameObject player;
	public AudioClip jump;

	private float x;
	private float y;

	void Start () 
	{
		Space2Start.SetActive (true);
	//	InvokeRepeating("blablu", 0.0f, 2.5f);
		StartCoroutine (Anim ());
	}

//	void blablu ()
//	{
//		StartCoroutine (Anim ());
//	}


	IEnumerator Anim()
	{
		yield return new WaitForSecondsRealtime(2.0f);
		Space2Start.SetActive (false);
		yield return new WaitForSecondsRealtime(1.0f);
		Space2Start.SetActive (true);
		StartCoroutine (Anim ());
	}


	IEnumerator Anim02()
	{
		Space2Start.SetActive (false);
		yield return new WaitForSecondsRealtime(0.05f);
		AudioSource.PlayClipAtPoint (jump, transform.position);
		yield return new WaitForSecondsRealtime(0.01f);
		player.GetComponent<Rigidbody>().AddForce (0.0f, 200.0f, 0.0f);
		yield return new WaitForSecondsRealtime(0.55f);
		SceneManager.LoadScene ("Scene 01");

	}



	void Update () {
		if (Input.GetKeyDown("space")) 
		{
			Debug.Log ("Start Game");
			StartCoroutine (Anim02());
		}
	}

}
