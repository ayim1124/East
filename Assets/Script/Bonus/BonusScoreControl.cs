using UnityEngine;
using System.Collections;

public class BonusScoreControl : BonusObjectControl {
	protected override void DealBonus (){
		MainManage.Instance.Score += 100;
		Destroy (gameObject);
	}
}
