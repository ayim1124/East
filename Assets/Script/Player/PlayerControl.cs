using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	const int _normalModScale = 20;
	const int _slowModScale = 10;
	const float _normalModSpeed = 1f;
	const float _slowModSpeed = 0.2f;

	public GameObject BulletSkill;

	bool _CanControl = true;
	bool _isSlowMod = false;
	float _speed;
	float _scale;
	bool _isPause = false;
	PlayerShoot _shoot;
	MoveToPoint _moveToPoint;
	GameObject _pauseMenu;

	void Awake () {
		_isSlowMod = false;
		_shoot = GetComponent< PlayerShoot > ();
		ChangeMoveMod ();
		_moveToPoint = GetComponent< MoveToPoint > ();
		_moveToPoint.enabled = false;
		_pauseMenu = GameObject.Find ("Pause");
		_pauseMenu.SetActive (false);
	}
	
	void Update () {
		if( _CanControl ){
			#region 模式切換
			if( Input.GetKeyDown( KeyCode.LeftControl ) ){
				_isSlowMod = true;
				ChangeMoveMod();
			}else if( Input.GetKeyUp( KeyCode.LeftControl ) ){
				_isSlowMod = false;
				ChangeMoveMod();
			}
			#endregion

			#region 移動控制
			if( Input.GetKey( KeyCode.UpArrow ) ){
				transform.Translate( Vector3.up * _speed * Time.deltaTime );
				if( transform.localPosition.y >= MainManage._maxHeight )
				   transform.localPosition = new Vector3( transform.localPosition.x, MainManage._maxHeight, 0 );
			}else if( Input.GetKey( KeyCode.DownArrow ) ){
				transform.Translate( Vector3.down * _speed * Time.deltaTime );
				if( transform.localPosition.y <= -MainManage._maxHeight )
					transform.localPosition = new Vector3( transform.localPosition.x, -MainManage._maxHeight, 0 );
			}

			if( Input.GetKey( KeyCode.LeftArrow ) ){
				transform.Translate( Vector3.left * _speed * Time.deltaTime );
				if( transform.localPosition.x <= -MainManage._maxWidth )
					transform.localPosition = new Vector3( -MainManage._maxWidth, transform.localPosition.y, 0 );
			}else if( Input.GetKey( KeyCode.RightArrow ) ){
				transform.Translate( Vector3.right * _speed * Time.deltaTime );
				if( transform.localPosition.x >= MainManage._maxWidth )
					transform.localPosition = new Vector3( MainManage._maxWidth, transform.localPosition.y, 0 );
			}
			#endregion
			
			#region 射擊控制
			if( Input.GetKey( KeyCode.X ) ){
				_shoot.Fire();
			}
			#endregion
		}

		#region 暫停控制
		if( Input.GetKeyDown( KeyCode.Escape ) ){
			Time.timeScale = ( _isPause? 1f: 0f );
			_isPause = !_isPause;
			_pauseMenu.SetActive(_isPause);
			if( _isPause ){
				MainManage.Instance.Output.text = "Pause";
				MainManage.Instance.Sound.BackSound.Pause();
			}else{
				MainManage.Instance.Output.text = "";
				MainManage.Instance.Sound.BackSound.Play ();
			}
		}
		#endregion

		#region AutoGain
		if (transform.localPosition.y >= 200f)
			MainManage.Instance.GainBonusByHeight();
		#endregion

		#region Special
		if ( Input.GetKeyUp( KeyCode.F1 ) )
			MainManage.Instance.Power = 30;
		if ( Input.GetKeyUp( KeyCode.F2 ) )
			MainManage.Instance.Life++;
		#endregion

		#region Skill
		/*if( Input.GetKeyUp( KeyCode.C ) ){
			GameObject bullet = ( GameObject )Instantiate( BulletSkill, transform.position, Quaternion.identity );
			bullet.transform.parent = MainManage.Instance.Bullet.transform;
			bullet.tag = tag;
		}*/
		#endregion
	}
	void ChangeMoveMod(){
		if( _isSlowMod ){
			_speed = _slowModSpeed;
			_scale = _slowModScale;
		}else{
			_speed = _normalModSpeed;
			_scale = _normalModScale;
		}
		transform.localScale = new Vector3 (_scale, _scale, 1);
	}

	internal void DealBoss(){
		_moveToPoint.Move ( Vector3.down*250f );
		_CanControl = false;
		Invoke ("OpenControl", MainManage._bossStopTime);
	}
	void OpenControl(){
		_CanControl = true;
	}
}
