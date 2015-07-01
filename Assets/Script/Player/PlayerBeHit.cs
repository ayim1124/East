using UnityEngine;
using System.Collections;

public class PlayerBeHit : MonoBehaviour {
	UISprite _icon;

	void Awake(){
		_icon = GetComponent< UISprite > ();
	}

	// 動畫
	void OnTriggerEnter2D( Collider2D Other ){
		if (Other.CompareTag (tag) == false) {
			collider2D.enabled = false;
			_icon.color = new Vector4( 255,0,0,0.3f );
			MainManage.Instance.Life -= 1;
			MainManage.Instance.Sound.Dead.Play();
			Invoke( "Reset", 1.5f );
		}
	}

	void Reset(){
		collider2D.enabled = true;
		_icon.color = new Vector4( 255,255,255,1f );
		//_icon.alpha = 1f;
	}
}
