using UnityEngine;
using System.Collections;

public class MoveRandomX : MoveLine {
	public float SpeedRangeX = 0.08f;

	void Start(){
		SpeedY = Random.Range (-3, 3) * SpeedRangeX / 3f;
	}	
}
