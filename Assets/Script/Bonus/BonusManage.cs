using UnityEngine;
using System.Collections;

public class BonusManage : MonoBehaviour {
	public GameObject[] Bonus;	

	// 0 power 1 score 2
	internal void CreateBonus( Vector3 startPosition, int index, int amount = 1 ){
		for( int i = 0; i < amount; i++ ){
			startPosition += new Vector3 (Random.Range (-30, 30), Random.Range(5, 15), 0);
			GameObject bonusItem = (GameObject)Instantiate( Bonus[ index ] );
			bonusItem.transform.parent = transform;
			bonusItem.transform.localPosition = startPosition;
			bonusItem.tag = tag;
		}
	}

	internal void AutoGainByHeight(){
		BroadcastMessage  ("AutoGain", SendMessageOptions.DontRequireReceiver);
	}
}
