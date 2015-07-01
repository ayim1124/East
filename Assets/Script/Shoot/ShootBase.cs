using UnityEngine;
using System.Collections;

public class ShootBase : MonoBehaviour {
	public float Interval = 0.2f;
	public GameObject Bullet;

	void FireBullet(){
		GameObject bullet = Instantiate (Bullet, transform.position, transform.rotation) as GameObject;
		bullet.transform.parent = MainManage.Instance.Bullet.transform;
		bullet.tag = tag;
		PlaySound ();
	}
	protected virtual void PlaySound(){;}

	void OnEnable(){
		InvokeRepeating ("FireBullet", Interval, Interval);
	}
	
	void OnDisable(){
		CancelInvoke ();
	}

	// player不可使用
	internal void ResetInterval( float interval ){
		CancelInvoke ();
		InvokeRepeating ("FireBullet", interval, interval);
	}

	#region 玩家發射用
	float nextFire = 0f;
	internal void Fire(){
		if ( Time.time > nextFire) {
			FireBullet();
			nextFire = Time.time + Interval;
		}
	}

	internal void CancelAuto(){
		CancelInvoke ();
	}


	#endregion
}
