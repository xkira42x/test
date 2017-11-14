using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	[SerializeField]
	AudioSource AS;
	[SerializeField]
	AudioClip[] AC=new AudioClip[3];
	[SerializeField]
	Animator AM;
	[SerializeField]
	GameObject TB;

	bool closeflg=false;
	bool sousouflg=false;
	bool btnflg = false;
	// Use this for initialization
	void Start () {
		AS.Play ();
	}

	// Update is called once per frame
	void Update () {
		if (AM.GetCurrentAnimatorStateInfo (0).normalizedTime>1&&
			closeflg==false) {
			AS.clip = AC [1];
			AS.Play ();
			closeflg = true;
			sousouflg = true;
		}
		if (sousouflg == true &&
		   !AS.isPlaying) {
			AS.clip = AC [2];
			AS.Play ();
			sousouflg=false;
			btnflg = true;
		}
		if(btnflg==true&&
			!AS.isPlaying){
			TB.SetActive (true);
		}
	}
	public void Title(){
		SceneManager.LoadScene ("title");
	}
}
