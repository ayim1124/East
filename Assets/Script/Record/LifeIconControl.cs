using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LifeIconControl : MonoBehaviour {
	List< SpriteRenderer > _lifes;

	void Awake(){
		_lifes = new List<SpriteRenderer>( GetComponentsInChildren< SpriteRenderer > () );
	}

	internal void SetLife( int life ){
		for( int i = 0; i < _lifes.Count; i++ ){
			if( i >= life ){
				_lifes[ i ].enabled = false;
			}else{
				_lifes[ i ].enabled = true;
			}
		}
	}
}
