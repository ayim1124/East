using UnityEngine;
using System.Collections;

public class RotateBySpeed : MonoBehaviour {
	public float Speed = 30f;
	
	void Update () {
		transform.Rotate (Vector3.forward * Speed * Time.deltaTime);
	}
}
