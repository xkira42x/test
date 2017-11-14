using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMText: MonoBehaviour {
	GameManager GMCp;
	TextMesh dbgText;
	byte laneLength;
	// Use this for initialization
	void Start () {
		GMCp=this.transform.parent.GetComponent<GameManager> ();
		dbgText = this.GetComponent<TextMesh> ();
		laneLength = GMCp.GetLaneLength();
		StartCoroutine ("ChgText");
	}
		
	IEnumerator ChgText(){
		while (true) {
			string pause="";
			for (int i=0; i < laneLength; i++) {
//				Debug.Log ("LL" + laneLength);
				pause += GMCp.GetLaneInEnemy ((byte)i).ToString()+"|";
			}
			dbgText.text = pause;
			yield return new WaitForSeconds (3f);
		}
	}
}