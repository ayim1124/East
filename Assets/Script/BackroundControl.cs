using UnityEngine;
using System.Collections;

public class BackroundControl : MonoBehaviour {
	int Height = 700;
	public float Speed = 0.0001f;

	void Update(){
		transform.Translate (0, Speed, 0);
		if( transform.localPosition.y >= Height/2 )
			transform.localPosition = Vector3.down*Height/2;
	}
}
