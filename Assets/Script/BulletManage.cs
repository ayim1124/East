using UnityEngine;
using System.Collections;

public class BulletManage : MonoBehaviour {
	bool _canShoot = true; 

	void Update(){
		if( _canShoot == false )
			Clear ();
	}

	public void DealBoss(){
		_canShoot = false;
		Invoke ("OpenShoot", MainManage._bossStopTime);
	}
	void OpenShoot(){
		_canShoot = true;
	}

	public void Clear(){
		for(int i = 0;i< transform.childCount;i++)
			Destroy(transform.GetChild(i).gameObject);
	}
}
