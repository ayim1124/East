using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour {
	List< ShootBase > _Shoot;
	public bool AutoShoot = true;
	public float OriginalInterval = 0.3f;

	void Awake(){
		_Shoot = new List<ShootBase>( GetComponentsInChildren< ShootBase >() );
	}

	void SetAutoShoot( bool isAutoShoot ){
		AutoShoot = isAutoShoot;
		SetPower (MainManage.Instance.Power);
	}

	internal void SetPower( int power ){
		SetShootSpeed( Mathf.Lerp (OriginalInterval, OriginalInterval/2f, power/30f) );

		foreach( ShootBase shoot in _Shoot )
			shoot.enabled = false;
		if (power < 10) {
			_Shoot[ 0 ].enabled = true;
		}else if(power < 20){
			_Shoot[ 1 ].enabled = true;
			_Shoot[ 2 ].enabled = true;
		}else if(power < 30 ){
			_Shoot[ 0 ].enabled = true;
			_Shoot[ 3 ].enabled = true;
			_Shoot[ 4 ].enabled = true;
		}else{
			for( int i = 1; i < _Shoot.Count; i++ )
				_Shoot[ i ].enabled = true;
		}

		if( AutoShoot == false )
			foreach( ShootBase shoot in _Shoot )
				shoot.CancelAuto();
			
	}
	void SetShootSpeed( float interval ){
		foreach( ShootBase shoot in _Shoot )
			shoot.Interval = interval;
	}

	internal void Fire(){
		if( AutoShoot == false )
			foreach( ShootBase shoot in _Shoot )
				if( shoot.enabled )
					shoot.Fire ();
	}
}
