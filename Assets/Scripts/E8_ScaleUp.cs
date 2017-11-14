using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E8_ScaleUp : MonoBehaviour {
	//拡大値を格納する
	float scalesize;
	//現在のスケールを返す
	public float GetNowScale{get{return this.transform.localScale.x;} }

	GameManager GM;

	void Start(){
		//コンポーネントの取得
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		//拡大値を取得
		scalesize=GM.GetScale;
	}
	// Update is called once per frame
	void Update () {
		//拡大値ずつ拡大していく
		this.gameObject.transform.localScale += new Vector3 (scalesize, scalesize, 0);
	}
}
