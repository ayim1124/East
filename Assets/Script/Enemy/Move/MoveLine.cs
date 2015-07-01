using UnityEngine;
using System.Collections;

public class MoveLine : EnemyMoveBase {
	// 調整X,Y的速度
	protected override void Move (){
		transform.Translate (SpeedX*Time.deltaTime, SpeedY*Time.deltaTime, 0);
	}
}
