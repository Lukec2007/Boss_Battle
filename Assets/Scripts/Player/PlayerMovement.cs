using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public float attackCooldown = 1f; // Time in seconds between attacks

	private float nextAttackTime = 0f;
	private float horizontalMove = 0f;
	private bool jump = false;
	private bool crouch = false;
	private bool attack = false;

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		// Attack input with cooldown
		if (Input.GetButtonDown("Attack") && Time.time >= nextAttackTime)
		{
			attack = true;
			nextAttackTime = Time.time + attackCooldown;
			animator.SetBool("IsAttacking", true);
		}
		else if (Input.GetButtonUp("Attack"))
		{
			attack = false;
			animator.SetBool("IsAttacking", false);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
