using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroke : MonoBehaviour {

	private Vector2 currentCursor;
	private Vector2 lastCursor;
	private double linearSpeed;
	private Vector2 currentAngle;
	private Vector2 lastAngle;
	private double angularSpeed;

	void Start () {
		this.currentCursor = Vector2.zero;
		this.lastCursor = Vector2.zero;
		this.linearSpeed = 0;
		this.currentAngle = Vector2.up;
		this.lastAngle = Vector2.up;
		this.angularSpeed = 0;
	}
	
	void Update () {

		// update cursor
		this.lastCursor = this.currentCursor;
		var position = Input.mousePosition;
		this.currentCursor = new Vector2(position.x, position.y);

		// update linear speed
		var last_linear_speed = this.linearSpeed;
		var next_linear_speed = (this.currentCursor - this.lastCursor).magnitude;
		this.linearSpeed = last_linear_speed * .95 + next_linear_speed * .05;

		// update angle
		this.lastAngle = this.currentAngle;
		this.currentAngle = (this.currentCursor - this.lastCursor).normalized;

		// update angular speed
		var last_angular_speed = this.angularSpeed;
		var next_angular_speed = 0.0;
		if (this.currentAngle != Vector2.zero) {
			next_angular_speed = 1.0 - Mathf.Abs(Vector2.Dot(this.currentAngle, this.lastAngle));
		}
		this.angularSpeed = last_angular_speed * .95 + next_angular_speed * .05;

	}

	public double getLinearSpeed() {
		var weighted_speed = this.linearSpeed / 500.0;
		return Math.Min(Math.Max(0, weighted_speed), 1);
	}

	public double getAngularSpeed() {
		var weighted_speed = this.angularSpeed * 3;
		return Math.Min(Math.Max(0, weighted_speed), 1);
	}

	public double getAggregateSpeed() {
		return Math.Max(this.getLinearSpeed(), this.getAngularSpeed());
	}
}
