using UnityEngine;
using System.Collections;

public class MoveLineThrow : EnemyMoveBase {
	// 調整X,Y的速度
	protected override void Move (){
		transform.Translate (SpeedX*Time.deltaTime, SpeedY*Time.deltaTime, 0);
		if( transform.localPosition.x >= MainManage._maxWidth ){
			SpeedX *= -1*Mathf.Sign( SpeedX );
		}else if( transform.localPosition.x <= -MainManage._maxWidth ){
			SpeedX *= Mathf.Sign( SpeedX );
		}
	}
}
