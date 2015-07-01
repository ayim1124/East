using UnityEngine;
using System.Collections;

public class RotatePart : MonoBehaviour {
	public float Speed = 0.1f;
	public float maxAngel = 60f;

	Quaternion from;
	Quaternion to;

	void Start(){
		from.eulerAngles = (transform.rotation.eulerAngles - Vector3.forward*maxAngel);
		to.eulerAngles = (transform.rotation.eulerAngles + Vector3.forward*maxAngel); 
	}

	void Update () {
		/*print (transform.localRotation.eulerAngles.z);
		transform.Rotate (Vector3.forward * Speed * Time.deltaTime);
		if( transform.localRotation.eulerAngles.z >= maxAngel ){
			Speed *= -1*Mathf.Sign( Speed );
		}else if( transform.localRotation.eulerAngles.z <= -maxAngel ){
			Speed *= Mathf.Sign( Speed );
		}*/
		transform.localRotation = Quaternion.Slerp (from, to, Mathf.PingPong( Time.time*Speed, 1 ));
	}
}
