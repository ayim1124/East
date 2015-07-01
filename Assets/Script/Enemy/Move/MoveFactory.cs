using UnityEngine;
using System.Collections;

public class MoveFactory : MonoBehaviour {
	// 0 不移動
	// 1 直線
	// 2 左右

	internal static EnemyMoveBase CreateMove( int moveStyle, GameObject enemy ){
		EnemyMoveBase move = null;
		switch (moveStyle) {
		case 1:
			move = enemy.AddComponent< MoveLine >();
			break;
		case 2:
			move = enemy.AddComponent< MoveLineThrow >();
			break;
		}
		return move;
	}
}
