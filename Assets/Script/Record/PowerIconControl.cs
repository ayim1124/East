using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerIconControl : MonoBehaviour {
	List< UISprite > _powers;

	void Awake(){
		_powers = new List<UISprite>( GetComponentsInChildren< UISprite > () );
	}
	
	internal void SetPower( int power ){
		if (power == 30) {
			foreach( UISprite icon in _powers )
				icon.fillAmount = 1f;
		}else{
			int powerLevel = power/10;
			for( int i = 0; i < _powers.Count; i++ ){
				if( i < powerLevel )
					_powers[ i ].fillAmount = 1f;
				else if( i == powerLevel )
					_powers[ i ].fillAmount = (power % 10)/10f;
				else
					_powers[ i ].fillAmount = 0f;
			}
		}
	}
}
