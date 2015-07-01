using UnityEngine;
using System.Collections;

public class BossControl : EnemyControl {
	EnemyMoveBase _move = null;
	public bool IsFinal{ private get; set; }

	void Awake () {
		_move = GetComponent< EnemyMoveBase > ();
		collider2D.enabled = false;
		if (_move != null) {
			_move.enabled = false;
		}
		CurrentLife = MainManage.Instance.Life;
		CurrentTime = Time.time;
		Invoke( "StartBoss", MainManage._bossStopTime );
	}
	void StartBoss(){
		collider2D.enabled = true;
		if( _move != null )
			_move.enabled = true;
	}

	int CurrentLife;
	float CurrentTime;
	protected override void Dead (){
		float useTime = Time.time - CurrentTime;
		MainManage.Instance.Output.text = "Stage Clear";
		MainManage.Instance.Bullet.Clear ();
		if (CurrentLife == MainManage.Instance.Life && useTime <= 25f ) {
			MainManage.Instance.Score += 10000;
			MainManage.Instance.Output.text += "\nBonus Score:10000";
		}
		if( IsFinal )
			MainManage.Instance.Victory();
		base.Dead ();
	}
}
