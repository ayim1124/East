using UnityEngine;
using System.Collections;

public class EnemyManage : MonoBehaviour {
	int _timer = 0;
	public GameObject[] EnemyPrefab;
	public GameObject[] BossPrefab;

	void Update () {
		if (Mathf.FloorToInt (Time.time) > _timer) {
			_timer = Mathf.FloorToInt (Time.time);
			switch( _timer ){
			case 1:
				EnterStage( 1 );
				for( int i = 0; i < 5; i++ )
					StartCoroutine( CreateEnemy(0+i*0.6f, 0, new Vector3( 320, 330, 0f ), 1, 100, (i+1)&1, 5, 0.5f, 2, -0.3f, -0.1f, 0f ) );
				break;
			case 2:
				for( int i = 0; i < 5; i++ )
					StartCoroutine( CreateEnemy(0+i*0.6f, 0, new Vector3( -320, 330, 0f ), 1, 100, i&1, 5, 0.5f, 2, 0.3f, -0.1f, 0f ) );
				break;
			case 3:
				MainManage.Instance.Output.text = "";
				break;
			case 6:
				for( int i = 0; i < 5; i++ ){
					StartCoroutine( CreateEnemy(0+i, 0, new Vector3( 100+i, 340, 0f ), 1, 100, (i+1)&1, 5, 1.5f, 1, 0.05f, -0.15f, -15f ) );
					StartCoroutine( CreateEnemy(0+i, 0, new Vector3( -100+i, 340, 0f ), 1, 100, i&1, 5, 1.5f, 1, -0.05f, -0.15f, 15f ) );
				}
				break;
			case 15:
				StartCoroutine( CreateEnemy(0, 1, new Vector3( 320, 350, 0f ), 10, 150, 1, 6, 0.5f, 2, -0.5f, -0.08f, 0f ) );
				break;
			case 20:
				StartCoroutine( CreateEnemy(0, 1, new Vector3( -320, 350, 0f ), 10, 150, 1, 6, 0.5f, 2, 0.5f, -0.08f, 0f ) );
				break;
			case 25:
				for( int i = 0; i < 5; i++ )
					StartCoroutine( CreateEnemy(0+i, 2, new Vector3( 330, 300, 0f ), 8, 300, i&1, 5, 0, 1, -0.15f, -0.08f, 0f ) );
				break;
			case 32:
				for( int i = 0; i < 5; i++ )
					StartCoroutine( CreateEnemy(0+i, 2, new Vector3( -330, 300, 0f ), 8, 300, i&1, 5, 0, 1, 0.15f, -0.08f, 0f ) );
				break;
			case 40:
				for( int i = 0; i < 5; i++ ){
					StartCoroutine( CreateEnemy(0+i, 2, new Vector3( 320, 300, 0f ), 5, 300, i&1, 5, 0, 2, -0.3f, 0f, 0f ) );
					StartCoroutine( CreateEnemy(0+i, 2, new Vector3( -320, 300, 0f ), 5, 300, i&1, 5, 0, 2, 0.3f, 0f, 0f ) );
				}
				break;
			case 51:
				ClearEnemy ( 0 );
				break;
			case 60:
				CreateBoss( 0, Vector3.up*100f );
				break;
			case 90:
				ClearEnemy ( 0 );
				break;
			case 95:
				EnterStage( 2 );
				for( int i = 0; i < 5; i++ ){
					StartCoroutine( CreateEnemy(0+i, 1, new Vector3( 320, 310, 0f ), 8, 300, i&1, 5, 0.8f, 2, -0.3f, 0f, 0f ) );
					StartCoroutine( CreateEnemy(0+i, 1, new Vector3( -320, 310, 0f ), 8, 300, i&1, 5, 0.8f, 2, 0.3f, 0f, 0f ) );
				}
				break;
			case 105:
				for(int i = 0; i < 4; i++ ){
					StartCoroutine( CreateEnemy(0+i*2, 3, new Vector3( 300-90*i, 330f, 0f ), 20, 300, i&1, 5, 0f, 1, -0.05f, -0.02f, 0f ) );
					StartCoroutine( CreateEnemy(0+i*2, 3, new Vector3( -300+80*i, 330f, 0f ), 20, 300, i&1, 5, 0f, 1, 0.05f, -0.02f, 0f ) );
				}
				break;
			case 120:
				for(int i = 0; i < 10; i++ ){
					StartCoroutine( CreateEnemy(0+i*2, 4, new Vector3( 320, 330f, 0f ), 10, 300, i&1, 5, 0.5f, 2, -0.1f, -0.05f, 0f ) );
					StartCoroutine( CreateEnemy(0+i*2, 4, new Vector3( -320, 330f, 0f ), 10, 300, i&1, 5, 0.5f, 2, 0.1f, -0.05f, 0f ) );
				} 
				break;
			case 143:
				ClearEnemy ( 0 );
				break;
			case 148:
				CreateBoss( 1, Vector3.up * 50f, true );
				break;
			}
		}
	}

	IEnumerator CreateEnemy( float waitTime, int index, Vector3 startPosition, int hp, int score, int bonusPower, int bonusScore, float shootSpeed = 0, int moveStyle = 0, float speedX = 0, float speedY = 0, float bulletRotate = 0 ){
		yield return new WaitForSeconds(waitTime);
		GameObject temp = (GameObject)Instantiate (EnemyPrefab [index]);
		temp.transform.parent = transform;
		EnemyControl enemy = temp.GetComponent< EnemyControl > ();
		enemy.SetEnemy(startPosition, hp, score, bonusPower, bonusScore, shootSpeed, moveStyle, speedX, speedY, bulletRotate ); 
	}

	void CreateBoss( int index, Vector3 startPosition, bool isFinal = false ){
		MainManage.Instance.BossComing ();
		GameObject enemy = (GameObject)Instantiate (BossPrefab [index]);
		enemy.transform.parent = transform;
		enemy.transform.localPosition = new Vector3 (-340f, 380f, 0f);
		enemy.AddComponent< MoveToPoint > ().Move (startPosition, 3f);
		if( isFinal )
			enemy.GetComponent< BossControl >().IsFinal = true;
	}

	internal void ClearEnemy( int index ){
		BroadcastMessage ("ClearWithType", 0f, SendMessageOptions.DontRequireReceiver);
	}

	void EnterStage( int level ){
		MainManage.Instance.Output.text = "Stage " + level.ToString();
		Invoke ("ClearText", 2f);		
	}

	void ClearText(){
		MainManage.Instance.Output.text = "";
	}

}
