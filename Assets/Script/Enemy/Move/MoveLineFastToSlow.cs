using UnityEngine;
using System.Collections;

public class MoveLineFastToSlow : MoveLine {
	public float SlowTime = 1.5f;

	void Start(){
		Invoke ("ChangeSpeed", SlowTime);
	}
	void ChangeSpeed(){
		SpeedY *= 0.4f;
	}
}
