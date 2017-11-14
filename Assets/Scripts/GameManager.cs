using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	short[,] lane=new short[3,2];

	[SerializeField]
	float scalesize;
	public float GetScale{ get { return scalesize; } }

	[SerializeField]
	float enemymovespd;
	public float GetEnemyMoveSpd{get{ return enemymovespd;}}
	[SerializeField]
	float enemyspwnspd;
	public float GetEnemySpwnSpd{get{ return enemyspwnspd;}}
	[SerializeField]
	byte enemy_max;
	public byte GetEnemyMax{get{ return enemy_max;}}
	[SerializeField]
	byte enemy_limit;
	public byte GetEnemyLimit{get{ return enemy_limit;}}
	[SerializeField]
	Sprite[] obasprites;
	[SerializeField]
	Sprite[] backsprites;
	[SerializeField]
	Sprite[] nowbacksprite;
	[SerializeField]
	byte[] step;
	public byte backflg{ get; set;}
	[SerializeField]
	GameObject[] button;
	[SerializeField]
	Vector2 differencesize;
	public Vector2 GetDifferenceSize{get{ return differencesize;}}
	[SerializeField]
	float closemovespd;
	public float GetDoorCloseSpd{ get { return closemovespd; } }
	[SerializeField]
	float openmovespd;
	public float GetDoorOpenSpd{ get { return openmovespd; } }
	[SerializeField]
	GameObject[] Doors;
	[SerializeField]
	GameObject massgage;
	public GameObject GetMassGage{ get { return massgage; } }
	[SerializeField]
	GameObject cam;
	public GameObject GetCamera{ get { return cam; } }
	[SerializeField]
	GameObject pushefect;
	public GameObject GetPushEffect{ get { return pushefect; } }



	// Use this for initialization
	void Start () {
		Debug.Log ("Call Game Manager");
		for (int i = 0; i < lane.GetLength(0); i++) {
			//レーンのｘ座標値を代入
			lane [i,0] = (short)GameObject.Find ("Lane" + i).transform.position.x;
			//レーン中の敵の数を初期化
			lane [i,1] = 0;
		}
	}

	public void EnemyInLane(byte ll){
		//ll番目のレーン中の敵の数を増やす
		lane [ll,1]++;
	}
	public void EnemyOutLane(byte ll){
		//ll番目のレーン中の敵の数を減らす
		lane [ll,1]--;
	}
	public short GetLaneX(byte ee){
		Debug.Log ("ee"+ee);
		return lane [ee,0];
	}
	public short GetLaneInEnemy(byte ee){
		return lane [ee,1];
	}
	public byte GetLaneLength(){
		return (byte)lane.GetLength(0);
	}

	public Sprite GetSprite(byte oo){
		return obasprites[oo];
	}
	public byte GetStep(byte ss){
		return step [ss];
	}
	public Sprite GetBack(byte bb){
		return nowbacksprite[bb];
	}
	public GameObject GetButton(byte bb){
		return button[bb];
	}
	public GameObject GetDoor(byte dd){
		return Doors[dd];
	}
	public void GameOver(){
		Debug.Log ("GameOver");
	}

}
