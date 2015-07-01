using UnityEngine;
using System.Collections;

public class BonusPowerControl : BonusObjectControl {
	protected override void DealBonus (){
		MainManage.Instance.Power += 1;
		Destroy (gameObject);
	}
}
