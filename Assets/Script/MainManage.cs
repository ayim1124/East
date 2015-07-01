using UnityEngine;
using System.Collections;

public sealed class MainManage : MonoBehaviour {
	#region 單例腳本建構

	private static MainManage _instance;
	public static MainManage Instance{
		get{
			if(_instance == null){
				_instance = FindObjectOfType< MainManage >();
				if(_instance == null){
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					_instance = obj.AddComponent< MainManage >();
				}
			}
			return _instance;
		}
	}
	#endregion

	public const int _maxHeight = 342;
	public const int _maxWidth = 315;
	public const int _destroyHeight = 392;
	public const int _destroyWidth = 365;
	public const float _bossStopTime = 3f;
	public BulletManage Bullet{ get; private set; }
	public BonusManage Bonus{ get; private set; }
	public RecordManage Record{ get; private set; }
	public PlayerControl Player{ get; private set; }
	public UILabel Output{ get; private set; }
	public EnemyManage Enemy{ get; private set; }
	public SoundManage Sound{ get; private set; }
	public Vector3 PlayerPosition { 
		get{ 
			if( Player != null )
				return Player.transform.position;
			return Vector3.zero;
		}
	}

	#region PlayerData
	int _score;
	public int Score{ 
		get{ return _score; }
		set{ 
			_score = value;
			Record.SetScore( _score );
		}
	}
	int _life;
	public int Life{
		get{ return _life; }
		set{
			_life = Mathf.Clamp( value, 0, 5 );
			Record.SetLife( _life );
			if( _life == 0 )
				Defeat();
		}
	}
	PlayerShoot _shoot;
	int _power;
	public int Power{ 
		get{ return _power; }
		set{
			if( _power != 30 || value < 30 ){
				_power = Mathf.Clamp( value, 0, 30 );
				Record.SetPower( _power );
				if( _power%5 == 0 )
					_shoot.SetPower( _power );
			}
		}
	}
	#endregion
	
	void Awake(){
		if(_instance == null)
			_instance = GetComponent< MainManage >();
		Bullet = GetComponentInChildren< BulletManage > ();
		Record = GetComponentInChildren< RecordManage > ();
		Bonus = GetComponentInChildren< BonusManage > ();
		Player = GetComponentInChildren< PlayerControl > ();
		Enemy = GetComponentInChildren< EnemyManage > ();
		Sound = GetComponentInChildren< SoundManage > ();
		_shoot = Player.GetComponent< PlayerShoot > ();
		Output = GameObject.Find ("Output").GetComponent< UILabel >();
	}

	void Start(){
		Score = 0;
		Life = 5;
		Power = 0;
	}

	float startTime;
	public void BossComing(){
		Output.text = "WARRING";
		Bullet.DealBoss ();
		Player.DealBoss ();
		Invoke ("ClearText", _bossStopTime);
	}

	public void GainBonusByHeight(){
		Bonus.AutoGainByHeight();
	}

	void ClearText(){
		Output.text = "";
	}

	public void Victory(){
		Debug.LogWarning ( "Victory" );
		Invoke ("DealVictory", 5f);
	}
	void DealVictory(){
		Output.text = "Victory\nFinalScore: " + Score;
		Player.enabled = false;
		Enemy.enabled = false;
	}


	void Defeat(){
		Debug.LogWarning ( "Defeat" );
		Output.text = "Defeat\nFinalScore: " + Score;
		Enemy.CancelInvoke ();
		Enemy.enabled = false;
		Sound.BackSound.Stop ();
		Destroy( Player.gameObject );
	}
}
