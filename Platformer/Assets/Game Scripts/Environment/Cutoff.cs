using UnityEngine;
using System.Collections;

public class Cutoff : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	// stop player from moving past left side of Cutoff
	void Update () {
		if (Player.transform.position.x <= transform.position.x) {
			Player.transform.position = transform.position;
		}
	}
}
