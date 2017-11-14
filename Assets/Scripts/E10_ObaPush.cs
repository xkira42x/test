using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E10_ObaPush : MonoBehaviour {
	Animator AM;
	E67_ObaSc OS;
	void Start(){
		AM = this.GetComponent<Animator> ();
		OS = this.GetComponent<E67_ObaSc> ();
	}
	public void Push(){
		//マウスのクリック判定から消す為、タグを変える
		this.transform.tag = "Untagged";

		//アニメーションの再生
		AM.SetTrigger ("Push");

		//プッシュアニメーション中であるが、
		//プッシュアニメーションの再生が終了しているなら、
		//このオブジェクトを消す
		if(!AM.GetCurrentAnimatorStateInfo(0).IsName("Push"))
		Invoke ("End", 2f);
	}
	void End(){
		OS.StateChng ((byte)E67_ObaSc.state.des);
	}
}
