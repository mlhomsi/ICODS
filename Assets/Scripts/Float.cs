using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	public Transform Seta01;
	public float AmplitudeX;
	public float AmplitudeY;
	public float Frequencia;
	public float offsetX;
	public float offsetY;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3((Mathf.PingPong(Time.time*Frequencia, AmplitudeX))-offsetX, (Mathf.PingPong(Time.time*Frequencia, AmplitudeY))-offsetY, transform.position.z);
	}
}
