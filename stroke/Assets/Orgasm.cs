using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orgasm : MonoBehaviour {

	public Stroke stroke;

	public Slider difficulty;

	private double progress;

	void Start () {
		this.progress = 0;
	}
	
	void Update () {
		var speed_difference = Math.Abs(this.stroke.getAggregateSpeed() - this.progress);
		if (speed_difference > this.getTargetRange()) {
			this.progress = Math.Max(this.progress - .01, 0);
		} else {
			this.progress = Math.Min(this.progress + .01, 100);
		}
	}

	private double getTargetRange() {
		return .2 - this.difficulty.value;
	}

	public double getMinimumSpeed() {
		return this.progress - this.getTargetRange();
	}

	public double getMaximumSpeed() {
		return this.progress + this.getTargetRange();
	}

	public double getProgress() {
		return this.progress;
	}
}
