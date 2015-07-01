using UnityEngine;
using System.Collections;

public class MoveToPoint : MonoBehaviour {
	Vector3 _target = Vector3.zero;
	float _speed = 5f;

	void Update () {
		transform.localPosition = Vector3.MoveTowards (transform.localPosition, _target, _speed);
		if( transform.localPosition == _target )
			enabled = false;
	}

	internal void Move( Vector3 target, float speed = 5f ){
		_target = target;
		_speed = speed;
		enabled = true;
	}
}
