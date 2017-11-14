using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G12_Door : MonoBehaviour {

	bool doorflg=true;
	float closemovespd;
	float openmovespd;
	float movespd;
	enum door{
		LEFT,
		RIGHT
	}
	GameManager GM;
	GameObject[] Doors=new GameObject[2];
	AudioSource[] AS=new AudioSource[2];
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		closemovespd = GM.GetDoorCloseSpd;
		openmovespd = GM.GetDoorOpenSpd;
		//ドアのオブジェクトを取得
		for (byte i = 0; i < 2; i++) {
			Doors[i]=GM.GetDoor (i);
		}
		//下ボタンを押すおと
		AS[0] = this.GetComponent<AudioSource> ();
		//ドアが閉まる音
		AS[1] = this.transform.FindChild("elevator_door_open_C").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (doorflg == true) {
			movespd = closemovespd;
		} else {
			movespd = -openmovespd;
		}
		Doors [(int)door.LEFT].transform.position += new Vector3 (movespd, 0, 0);
		Doors [(int)door.RIGHT].transform.position -= new Vector3 (movespd, 0, 0);
		if (Doors [(int)door.RIGHT].transform.localPosition.x < 0.5f)
			GM.GameOver ();
		if (Doors [(int)door.RIGHT].transform.localPosition.x > 2.7f) {
			DownButton (true);
		}
	}

	public void DownButton(bool dd){
		doorflg = dd;
		if (doorflg) {
			AS [1].Play ();
		} else {
			AS [0].Play ();
		}
	}

}
