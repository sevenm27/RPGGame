﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	public Interactable focus;

	public LayerMask movementMask;

	Camera cam;
	PlayerMotor motor;
	// Use this for initialization
	void Start()
	{
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;



			if (Physics.Raycast(ray, out hit, 100, movementMask))
			{
				motor.MoveToPoint(hit.point);
				RemoveFocus();
			}	
		}
		//If we press right mouse
		if (Input.GetMouseButtonDown(1))
		{
			//We create a ray 
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			//If the ray hits
			if (Physics.Raycast(ray, out hit, 100))
			{
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				if (interactable != null)
				{
					SetFocus(interactable);
				}
			}
		}
	}
	void SetFocus(Interactable newFocus)
	{
		focus = newFocus;
		motor.FollowTarget(newFocus);
	}

	void RemoveFocus()
	{
		focus = null;
		motor.StopFollowingTarget();
	}
}



