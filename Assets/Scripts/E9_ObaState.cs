using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E9_ObaState : MonoBehaviour {
	E8_ScaleUp SU;
	SpriteRenderer SR;
	GameManager GM;

	// Use this for initialization
	void Start () {
		//コンポーネントの取得
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		SU = this.gameObject.GetComponent<E8_ScaleUp> ();
		SR = this.GetComponentsInChildren<SpriteRenderer> ()[0];
	}
	
	public void SpriteCheng(){
		//おばちゃんのスケールを取得
		float nowscale=SU.GetNowScale;

		//スケール値がStep[0]値よりも大きく,
		//Step[1]値よりも小さい時Spriteを切り替える
		if (nowscale >= (float)GM.GetStep(0) && nowscale < (float)GM.GetStep(1)) {
			SR.sprite = GM.GetSprite (1);
		} else
			//Step[1]値よりも大きい時Spriteを切り替える
			if(nowscale>=(float)GM.GetStep(1)){
				SR.sprite=GM.GetSprite(2);
			}
	}
}
