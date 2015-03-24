using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void FixedUpdate(){
		float MoveHorizontal=Input.GetAxis("Horizontal");
		float MoveVertical=Input.GetAxis("Vertical");
		rigidbody.velocity = new Vector3 (MoveHorizontal, 0, MoveVertical)*speed;
		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -tilt);
	}	
	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			audio.Play();
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
