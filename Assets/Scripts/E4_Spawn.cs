using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Spawn : MonoBehaviour {
	[SerializeField]
	GameObject Oba;

	string Obaname="Oba";
	GameManager GM;
	[SerializeField]
	float spwnspd=0.5f;
	[SerializeField]
	byte maxspn=50;
 	// Use this for initialization
	void Start () {
		GM=GameObject.Find ("GameManager").GetComponent<GameManager> ();
		StartCoroutine ("Spn");
	}

	IEnumerator Spn(){
		while(true){
			GameObject Obj;
			Obj=Instantiate (Oba,transform.position,transform.rotation).gameObject;
			Obj.name=Obaname+GM.GetEnCnt;
			Debug.Log ("おばちゃん生成"+GM.GetEnCnt);
			if (GM.GetEnCnt > maxspn) {
				GM.GetEndFlg = true;
				break;
			}
			yield return new WaitForSeconds(spwnspd);
		}
	}
}
