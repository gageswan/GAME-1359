﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 6f;

	public int playerIndex = 1;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal" + playerIndex);
		float v = Input.GetAxisRaw("Vertical" + playerIndex);

		Move(h, v);
		Turning();
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{	if (playerIndex == 1) {
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit floorHit;

			if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;

				Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
				playerRigidbody.MoveRotation(newRotation);
			}
		}
		else {
			transform.Rotate(0, Input.GetAxis("Rotational") * 0.5f * speed, 0);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("IsWalking", walking);
	}
}
