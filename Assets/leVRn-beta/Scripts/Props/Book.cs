using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Prop
{
    private static readonly int Fall = Animator.StringToHash("Fall");

    // Start is called before the first frame update
    public override void AnimateProp(){
        
        Debug.Log("Book prop");
        anim.SetTrigger(Fall);
    }

    public void BookFalling(){
        AnimateBar(potentialEnergy, 0, 0.53f);
       // AnimateBar(velocity, 10, 0.53f);
    }

    public void BookSliding(){
        //AnimateBar(velocity, 2, 0.15f);
    }

    public void BookOnGround(){
        //velocity.UpdateBar(0,maxVelocity);
    }
   
}
