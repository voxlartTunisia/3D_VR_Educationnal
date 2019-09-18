using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizTracker", menuName = "Misc/QuizTracker")]
public class QuizTracker : ScriptableObject
{
    public GameObject experienceStats;
    [NonSerialized]
    public List<QuizDetails> quizzes = new List<QuizDetails>();
    
    public struct QuizDetails
    {
        public string name;
        public float timeTaken; //in seconds
        public Status status;
        
        public enum Status{PASS, FAILED}

        public QuizDetails(string quizName, float time, Status stat){
            name = quizName;
            timeTaken = time;
            status = stat;
        }
        
       
    }
}
