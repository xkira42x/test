using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObaText : MonoBehaviour {
	E67_ObaSc obaCp;
	TextMesh dbgText;

	// Use this for initialization
	void Awake () {
		obaCp=this.transform.parent.GetComponent<E67_ObaSc> ();
		dbgText = this.GetComponent<TextMesh> ();
		StartCoroutine ("ChgText");
	}

	IEnumerator ChgText(){
		while (true) {
			/**オバスクリプトからステータスをもらい
		 * ストリング変換を掛け
		 * テキストに変更を掛けている
		 * */
			dbgText.text = obaCp.GetState ().ToString ();
			dbgText.text += obaCp.GetlaneX ().ToString ();
			yield return new WaitForSeconds (1f);
		}
	}
}
