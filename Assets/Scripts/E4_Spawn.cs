using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_Spawn : MonoBehaviour {
	[SerializeField]
	GameObject Oba;

	string Obaname="Oba";
	GameManager GM;
	float spwnspd;
	// Use this for initialization
	void Start () {
		GM=GameObject.Find ("GameManager").GetComponent<GameManager> ();
		spwnspd = GM.GetEnemySpwnSpd;
		StartCoroutine ("Spn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Spn(){
		while(true){
			GameObject Obj;
			Obj=Instantiate (Oba,transform.position,transform.rotation).gameObject;
			Obj.name=Obaname+(byte)Time.time;
			Obj.GetComponent<E67_ObaSc> ();
			Debug.Log ("おばちゃん生成"+(byte)Time.time);
			yield return new WaitForSeconds(spwnspd);
		}
	}
}
