using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationTrigger", menuName = "Guide/AnimationTrigger")]
public class AnimationTriggers : ScriptableObject
{
    public bool WaveBegun{ get; set; }
    public bool WaveEnded{ get; set; }
    public bool PowerOnEnded{ get; set; }
    
    public bool HitEnded{ get; set; }

}
