using UnityEngine;
using System.Collections;

public abstract class EnemyMoveBase : MonoBehaviour {
	public float SpeedX = 0f;
	public float SpeedY = -0.1f;
	
	// Update is called once per frame
	void Update () {
		Move ();
		if (Mathf.Abs (transform.localPosition.y) >= MainManage._destroyHeight || Mathf.Abs (transform.localPosition.x) >= MainManage._destroyWidth) {
			Destroy( gameObject );
		}
	}

	protected abstract void Move();
}
