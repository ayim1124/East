using UnityEngine;
using System.Collections;

public class RecordManage : MonoBehaviour {
	UILabel _labelScore;
	LifeIconControl _recordLife;
	PowerIconControl _recordPower;

	void Awake(){
		_labelScore = GameObject.Find ("Score").GetComponent< UILabel >();
		_recordLife = GetComponentInChildren< LifeIconControl > ();
		_recordPower = GetComponentInChildren< PowerIconControl > ();
	}

	internal void SetScore( int score ){
		_labelScore.text = score.ToString();
	}

	internal void SetLife( int life ){
		_recordLife.SetLife (life);
	}

	internal void SetPower( int power ){
		_recordPower.SetPower (power);
	}
}
