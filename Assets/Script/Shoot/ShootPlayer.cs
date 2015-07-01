using UnityEngine;
using System.Collections;

public class ShootPlayer : ShootBase {
	protected override void PlaySound (){
		MainManage.Instance.Sound.Shoot.Play ();
	}
}
