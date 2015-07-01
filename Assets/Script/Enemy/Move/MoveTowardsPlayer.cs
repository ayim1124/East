using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : EnemyMoveBase {
	public float Speed = 0.5f;
	Vector3 _moveVector;

	void Start(){
		_moveVector = MainManage.Instance.PlayerPosition - transform.position;
		_moveVector.Normalize ();
		print (_moveVector);
		_moveVector *= Speed;
	}

	protected override void Move (){
		transform.Translate (_moveVector*Time.deltaTime);
	}

}
