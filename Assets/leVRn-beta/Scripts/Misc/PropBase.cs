using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class PropBase : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    public string propTitle;
    public GameObject answer;
    public GameObject arrow;
    public Transform guideLocation;
    private Outline[] outline;
    
    void Awake(){
        holder.propController.props[propTitle] = gameObject;
        
    }

    private void Start(){
        outline = GetComponentsInChildren<Outline>();
        Unhighlight();
    }

    public void Unhighlight(){
        for (int i = 0; i < outline.Length; i++){
            outline[i].enabled = false;
        }
    }

    public void Highlight(){
        for (int i = 0; i < outline.Length; i++){
            outline[i].enabled = true;
        }
    }
    
}
