using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
	public float Speed = 1f;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, MainManage.Instance.PlayerPosition, Time.deltaTime*Speed);
	}
}
