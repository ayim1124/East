using UnityEngine;
using System.Collections;

public abstract class BonusObjectControl : MonoBehaviour {
	BonusEffect _effect;
	FollowTarget _follow;

	// Use this for initialization
	void Awake () {
		_effect = GetComponent< BonusEffect > ();
		_effect.enabled = false;
		_follow = GetComponent< FollowTarget > ();
		_follow.enabled = false;
	}

	void AutoGain(){
		_follow.enabled = true;
	}

	void OnTriggerEnter2D( Collider2D Other ){
		if( Other.CompareTag( tag ) ){ // Player
			GetComponent< MoveLine > ().enabled = false;
			_follow.enabled = true;
			_effect.enabled = true;
			MainManage.Instance.Sound.Bonus.Play();
			Invoke( "DealBonus", 0.3f );
		}
	}
	protected abstract void DealBonus();
}
