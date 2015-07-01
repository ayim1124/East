using UnityEngine;
using System.Collections;

public class SoundManage : MonoBehaviour {
	public AudioSource BackSound;
	public AudioSource Dead;
	public AudioSource Shoot;
	public AudioSource Bonus;

	void SetSound( bool isSound ){
		float volume = (isSound ? 1f : 0f);
		BackSound.volume = volume;
		Dead.volume = volume;
		Shoot.volume = volume/5f;
		Bonus.volume = volume;
	}
}
