using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_InputKey : MonoBehaviour {

	Vector2 differencesize;
	GameManager GM;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GameManager").GetComponent<GameManager>();
		differencesize = GM.GetDifferenceSize;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			for (int i = 0; i < enemies.Length; i++) {
				if (Difference (mousePos, enemies [i].transform.position).x-enemies[i].transform.localScale.x/10f < differencesize.x &&
					Difference (mousePos, enemies [i].transform.position).y-enemies[i].transform.localScale.y/10f < differencesize.y) {
					E67_ObaSc OB = enemies [i].GetComponent<E67_ObaSc> ();
					OB.StateChng ((byte)E67_ObaSc.state.push);
					break;
				}
			}
			GameObject effect=Instantiate (GM.GetPushEffect,this.transform.position,new Quaternion(0,0,0,0));
			Destroy (effect, 0.2f);
		}
	}

	//マイナスをプラスに変換が必要
	Vector3 Difference(Vector3 aa,Vector3 bb){
		Vector3 sand=aa-bb;
		if (0 > sand.x)sand.x*=-1;
		if (0 > sand.y)sand.y*=-1;
		return 	sand;
	}
}
