using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableObjectsHolder")]
public class ScriptableObjectsHolder : ScriptableObject
{
    public AnimationTriggers animationTriggers;
    public SceneLoader sceneLoader;
    public PropController propController;
    public QuizTracker quizTracker;

    public int phase = 0;
}
