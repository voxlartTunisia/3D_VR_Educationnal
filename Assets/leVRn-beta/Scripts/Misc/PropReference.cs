using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropReference : MonoBehaviour
{
    public GameObject table;
    public GameObject book;
    public GameObject ball;
    
    public ScriptableObjectsHolder holder;
    private void Awake(){
        holder.propController.props["Table"] = table;
        holder.propController.props["Book"] = book;
        holder.propController.props["Ball"] = ball;
    }
}
