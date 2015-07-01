using UnityEngine;
using System.Collections;

public class BulletPlayer : MonoBehaviour {
	public float SpeedX = 0f;
	public float SpeedY = 2f;

	void Update () {
		transform.Translate (SpeedX*Time.deltaTime, SpeedY*Time.deltaTime, 0);
		if( transform.localPosition.y >= MainManage._maxHeight ){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D( Collider2D Other ){
		if (Other.CompareTag (tag) == false) {
			Other.SendMessage( "ApplyDamage", 1f );
			MainManage.Instance.Score += 10;
			Destroy( gameObject );
		}
	}
}
