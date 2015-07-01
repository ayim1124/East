using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	public int Score = 100;
	public int BonusPower = 1;
	public int BonusScore = 5;
	public int Hp = 5;
	public int Health{
		private get{ return Hp; }
		set{
			Hp = value;
			if( Hp <= 0 ){
				Dead ();
			}
		}
	}
	protected virtual void Dead(){
		MainManage.Instance.Score += Score;
		MainManage.Instance.Bonus.CreateBonus( transform.localPosition, 0, BonusPower );
		MainManage.Instance.Bonus.CreateBonus( transform.localPosition, 1, BonusScore );
		Destroy ( gameObject );
	}

	void ApplyDamage( int damage ){
		Health -= damage;
	}

	// 0 exit 1 destroy
	void ClearWithType( int type ){
		switch (type) {
		case 0:
			Destroy( GetComponent< EnemyMoveBase >() );
			for(int i = 0;i< transform.childCount;i++)
				Destroy(transform.GetChild(i).gameObject);
			gameObject.AddComponent< ExitByBoss >();
			break;
		case 1:
			Destroy( gameObject );
			break;
		default:
			Debug.LogError( "No Clear Type" );
			break;
		}
	}

	ShootBase shoot;
	internal void SetEnemy( Vector3 startPosition, int hp, int score, int bonusPower, int bonusScore, float shootSpeed = 0, int moveStyle = 0, float speedX = 0, float speedY = 0, float bulletRotate = 0 ){
		transform.localPosition = startPosition;
		Health = hp;
		Score = score;
		BonusPower = bonusPower;
		BonusScore = bonusScore;

		// 可預先設定
		shoot = GetComponentInChildren< ShootBase > ();
		if( shootSpeed > 0 )
			shoot.ResetInterval (shootSpeed);
		EnemyMoveBase move = MoveFactory.CreateMove (moveStyle, gameObject);
		if (move != null) {
			move.SpeedX = speedX;
			move.SpeedY = speedY;
		}
		shoot.transform.rotation = Quaternion.Euler (Vector3.forward * bulletRotate);
	}
}
