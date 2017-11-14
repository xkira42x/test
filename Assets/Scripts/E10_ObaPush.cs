using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E10_ObaPush : MonoBehaviour {
	Animator AM;
	E67_ObaSc OS;
	GameManager GM;
	AudioSource AS;
	float destroytime;
	void Start(){
		AM = this.GetComponent<Animator> ();
		OS = this.GetComponent<E67_ObaSc> ();
		GM = GameObject.Find("GameManager").GetComponent<GameManager> ();
		destroytime = GM.GetEnemyDestroyTime;
		AS = this.GetComponent<AudioSource> ();
	}
	public void Push(){
		//マウスのクリック判定から消す為、タグを変える
		this.transform.tag = "Untagged";

		//アニメーションの再生
		AM.SetTrigger ("Push");

		//プッシュアニメーション中であるが、
		//プッシュアニメーションの再生が終了しているなら、
		//このオブジェクトを消す
		if (!AM.GetCurrentAnimatorStateInfo (0).IsName ("Push")) {
			if(!AS.isPlaying)
			AS.Play ();
			Invoke ("End", destroytime);
		}
	}
	void End(){
		OS.StateChng ((byte)E67_ObaSc.state.des);
	}
}
