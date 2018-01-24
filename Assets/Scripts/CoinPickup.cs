using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public AudioClip collected;

	private AudioSource source;

	void OnTriggerEnter(Collider info)
	{
		if (info.name == "Player") 
		{
			Debug.Log ("collected");
			AudioSource.PlayClipAtPoint (collected, transform.position);
			Destroy (gameObject);
		}
	}
}
