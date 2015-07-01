using UnityEngine;
using System.Collections;

public class ExitByBoss : MoveLine {
	void Start(){
		SpeedX = 0.25f * Mathf.Sign (transform.position.x);
		SpeedY = 0.1f;
	}
}
