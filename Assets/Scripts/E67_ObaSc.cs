using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E67_ObaSc : MonoBehaviour {

	public enum state{
		init,
		move,
		push,
		des
	}
	float movespd;
	byte nowstate=0;
	short laneX=0;
	byte mylane;
	GameManager GM;
	E9_ObaState OS;
	E10_ObaPush OP;
	Slider massgage;
	byte limit;
	// Use this for initialization
	void Start () {
		Debug.Log ("Call BBA");
		GM = GameObject.Find ("GameManager").GetComponent<GameManager>();
		limit = GM.GetEnemyLimit;
		movespd = GM.GetEnemyMoveSpd;
		massgage = GM.GetMassGage.GetComponent<Slider>();
		OS = this.gameObject.GetComponent<E9_ObaState> ();
		OP = this.gameObject.GetComponent<E10_ObaPush> ();
		LaneSearch ();
	}
	
	// Update is called once per frame
	void Update () {
		switch ((int)nowstate) {
		case (int)state.init:
			Init ();
			break;
		case (int)state.move:
			Move ();
			OS.SpriteCheng ();
			break;
		case (int)state.push:
			OP.Push ();
			break;
		case (int)state.des:
			Destroy ();
			break;
		}
		
	}
	void Init(){
		this.transform.position = new Vector3 (laneX,
			this.transform.position.y,
			this.transform.position.z);
		StateChng ((byte)state.move);
	}

	void Move(){
		this.transform.position += new Vector3 (0,-movespd,0);
		if (this.transform.position.y < -limit) {
			massgage.value++;
			iTween.ShakePosition (GM.GetCamera, iTween.Hash ("y", 0.2f,"time", 0.2f));
			if (massgage.value == massgage.maxValue)
				GM.GameOver ();
			StateChng ((byte)state.des);
		}
			
	}
	//おばちゃんの状態を返す
	public byte GetState(){
		return nowstate;
	}

	//おばちゃんの状態を引数分変える
	public void StateChng(byte xx){
			nowstate = xx;
	}

	//おばちゃんの向かうレーンを探索する
	void LaneSearch(){
		byte rand;
		do{
			rand=(byte)Random.Range (0, GM.GetLaneLength());
		}while(GM.GetLaneInEnemy(rand)>=(short)GM.GetEnemyMax);
		mylane = rand;
		laneX = GM.GetLaneX (mylane);
		GM.EnemyInLane (mylane);
		Debug.Log ("lx" + laneX);
	}

	//おばちゃんのレーンを返す
	public short GetlaneX(){
		return laneX;
	}
	void Destroy(){
		GM.EnemyOutLane (mylane);
		Destroy (this.gameObject);
	}
}
