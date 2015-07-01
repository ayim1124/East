using UnityEngine;
using System.Collections;

public class LayerControl : MonoBehaviour {
	public GameObject Bullet;

	void Start () {
		collider2D.enabled = false;
		Invoke ("AddEffect", 1f);
		Invoke ("FireBullet", 4f);
	}
	void AddEffect(){
		gameObject.AddComponent< LayerEffect > ();
	}
	
	void FireBullet(){
		GameObject bullet = Instantiate (Bullet, transform.position, transform.rotation) as GameObject;
		bullet.transform.parent = MainManage.Instance.Bullet.transform;
		bullet.tag = tag;
	}
}
