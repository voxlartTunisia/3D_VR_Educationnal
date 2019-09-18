using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAsync;

public abstract class Prop : PropBase
{
    public SimpleHealthBar potentialEnergy;
    public SimpleHealthBar kineticEnergy;
    public SimpleHealthBar velocity;

    public float maxPotential;
    public float maxKinetic;
    public float maxVelocity;

    public float initialPotential;
    public float initialKinetic;
    public float initialVelocity;

    
    public Text titleText;

    protected Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
        titleText.text = propTitle;
        ResetBars();
    }

    protected async void AnimateBar(SimpleHealthBar bar, float newValue, float time, int steps = 10){
        float difference = bar.value - newValue;
        float fraction = difference/steps;
        float timeInterval = time / steps;

        for (int i = 0; i < steps; i++){
            //await new WaitForSeconds(timeInterval);
            await new UnityAsync.WaitForSeconds(timeInterval);
            bar.UpdateBar(bar.value - fraction, bar.maxValue);
        }
    }

    protected void ResetBars(){
        potentialEnergy.maxValue = maxPotential;
        kineticEnergy.maxValue = maxKinetic;
        velocity.maxValue = maxVelocity;
        potentialEnergy.UpdateBar(initialPotential, maxPotential);
        kineticEnergy.UpdateBar(initialKinetic, maxKinetic);
        velocity.UpdateBar(initialVelocity, maxVelocity);
    }

    public abstract void AnimateProp();




}
