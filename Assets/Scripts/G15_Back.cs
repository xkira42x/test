using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G15_Back : MonoBehaviour {

	GameManager GM;
	SpriteRenderer SR;

	enum BG{
		FRONT,
		BACK,
		DOWN
	}

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		SR=GameObject.Find("background").GetComponent<SpriteRenderer> ();
	}

	//後ろを向く
	public void Back(){
		SR.sprite = GM.GetBack ((byte)BG.BACK);
		SR.sortingOrder = 1;
		GM.GetDoor (0).GetComponent<SpriteRenderer> ().sortingOrder = 2;
		GM.GetDoor (1).GetComponent<SpriteRenderer> ().sortingOrder = 2;
		GM.GetDoor (2).GetComponent<SpriteRenderer> ().sortingOrder = 5;
		GM.backflg = (byte)BG.BACK;
		GM.GetButton ((byte)BG.FRONT).SetActive(true);
		GM.GetButton ((byte)BG.BACK).SetActive(false);
		GM.GetButton ((byte)BG.DOWN).SetActive(true);
	}
	//正面へ戻る
	public void Front(){
		SR.sprite = GM.GetBack ((byte)BG.FRONT);
		SR.sortingOrder = -1;
		GM.GetDoor (0).GetComponent<SpriteRenderer> ().sortingOrder = -2;
		GM.GetDoor (1).GetComponent<SpriteRenderer> ().sortingOrder = -2;
		GM.GetDoor (2).GetComponent<SpriteRenderer> ().sortingOrder = -5;
		GM.backflg = (byte)BG.FRONT;
		GM.GetButton ((byte)BG.BACK).SetActive(true);
		GM.GetButton ((byte)BG.FRONT).SetActive(false);
		GM.GetButton ((byte)BG.DOWN).SetActive(false);
	}
}
