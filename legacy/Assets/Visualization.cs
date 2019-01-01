using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualization : MonoBehaviour {

	public Stroke stroke;
	public Orgasm orgasm;

	public Slider linearSpeed;
	public Slider angularSpeed;
	public Slider aggregateSpeed1;
	public Slider aggregateSpeed2;
	public Slider desiredSpeedMinimum;
	public Slider desiredSpeedMaximum;
	public Slider orgasmProgress;
	
	void Update () {
		this.linearSpeed.value = (float)this.stroke.getLinearSpeed();
		this.angularSpeed.value = (float)this.stroke.getAngularSpeed();
		this.aggregateSpeed1.value = (float)this.stroke.getAggregateSpeed();
		this.aggregateSpeed2.value = (float)this.stroke.getAggregateSpeed();
		this.desiredSpeedMinimum.value =  (float)this.orgasm.getMinimumSpeed();
		this.desiredSpeedMaximum.value =  (float)this.orgasm.getMaximumSpeed();
		this.orgasmProgress.value = (float)this.orgasm.getProgress();
	}
}
