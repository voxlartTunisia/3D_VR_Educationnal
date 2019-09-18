using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outline = cakeslice.Outline;

[CreateAssetMenu(fileName = "PropController", menuName = "Misc/PropController")]
public class PropController : ScriptableObject
{
    public Dictionary<string, GameObject> props = new Dictionary<string, GameObject>();
    private static readonly int Default = Animator.StringToHash("Default");

    public enum Answer
    {
        Right,
        Wrong,
        Unanswered
    };
    [NonSerialized] public Transform guideLocation;

    [NonSerialized] public Answer answer = Answer.Unanswered;

    public void ActivateBookExample(){
        props["Table"].SetActive(true);
        props["Book"].SetActive(true);
    }

    public void ActivateBall(){
        props["Ball"].SetActive(true);
    }

    public void HighlightProp(string propTitle){
        props[propTitle].GetComponent<PropBase>().Highlight();     
        DisplayArrow(propTitle);
    }

    public void UnhighlightProp(string propTitle){
        props[propTitle].GetComponent<PropBase>().Unhighlight();
        RemoveArrow(propTitle);
    }

    public void DisplayArrow(string propTitle){
        GameObject arrow = props[propTitle].GetComponent<PropBase>().arrow;
        if (arrow != null)
            arrow.SetActive(true);
    }
    
    void RemoveArrow(string propTitle){
        GameObject arrow = props[propTitle].GetComponent<PropBase>().arrow;
        if (arrow != null)
            arrow.SetActive(false);
    }

    public void TurnOnGravity(string propTitle){
        props[propTitle].GetComponent<Rigidbody>().useGravity = true;
    }

    public void TurnOffKinematic(string propTitle){
        props[propTitle].GetComponent<Rigidbody>().isKinematic = false;
    }
    public void DefaultAnimation(string propTitle){
        props[propTitle].GetComponentInChildren<Animator>().SetTrigger(Default);
    }

    public void PlayDefaultAudio(string propTitle){
        props[propTitle].GetComponentInChildren<AudioSource>().Play();
    }

    public void SetGuideLocation(string propTitle){
        guideLocation = props[propTitle].GetComponent<PropBase>().guideLocation;
    }
    
    public void DisplayQuestion(string propTitle){
        props[propTitle].GetComponent<PropBase>().answer.SetActive(true);
    }
    
    public void RemoveQuestion(string propTitle){
        props[propTitle].GetComponent<PropBase>().answer.SetActive(false);
    }
    
    
}
