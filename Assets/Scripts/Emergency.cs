using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergency : MonoBehaviour {

	[SerializeField]
	G12_Door GD;
	GameManager GM;
	void Start(){
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	public void EmStop(){
		iTween.ShakePosition (GM.GetCamera, iTween.Hash ("y", 0.8f,"time", 0.5f));
		GD.enabled = false;
		Invoke ("EmStart", 10f);
	}
	void EmStart(){
		iTween.ShakePosition (GM.GetCamera, iTween.Hash ("y", 0.8f,"time", 0.3f));
		GD.enabled = true;
	}
}
