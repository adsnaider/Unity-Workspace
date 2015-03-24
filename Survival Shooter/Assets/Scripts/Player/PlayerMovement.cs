﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float h=Input.GetAxisRaw("Horizontal");
		float v=Input.GetAxisRaw("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);

	}
	void Move(float h, float v){
		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position+movement);
	}
	void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 PlayerToMouse=floorHit.point-transform.position;
			PlayerToMouse.y=0;
			Quaternion newRotation=Quaternion.LookRotation(PlayerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}
	void Animating(float h,float v){
		bool walking = h != 0 || v != 0;
		anim.SetBool ("IsWalking", walking);
	}
}

