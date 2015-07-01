using UnityEngine;
using System.Collections;

public class LayerEffect : MonoBehaviour {
	const float _minSize = 4f;
	const float _maxSize = 50f;

	bool _isDone = false;
	float _timer = 0f;
	UISprite _icon;

	// Use this for initialization
	void Start () {
		_icon = GetComponent< UISprite > ();
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;
		if (_isDone == false) {
			transform.localScale = new Vector3( Mathf.Lerp( _minSize, _maxSize, _timer ), 468f , 1f );
			if( transform.localScale.x == _maxSize ){
				collider2D.enabled = true;
				_isDone = true;
				_timer = 0;
				enabled = false;
				Invoke( "Open", 1f );
			}
		}else{
			transform.localScale = new Vector3( Mathf.Lerp( _maxSize, _minSize, _timer/2.5f ), 468f , 1f );
			_icon.alpha = Mathf.Lerp( 1f, 0f, _timer/2.5f );
			if( _icon.alpha == 0 )
				Destroy( gameObject );
		}
	}

	void Open(){
		enabled = true;
	}
}
