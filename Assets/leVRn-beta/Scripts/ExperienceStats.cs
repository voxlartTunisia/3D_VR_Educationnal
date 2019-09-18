using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceStats : MonoBehaviour
{
    public ScriptableObjectsHolder holder;

    public TextMeshProUGUI displayText;

    private void Start(){
        displayText.text = $"Quiz Results\nTotal time taken for experience = {Time.time}\n\n";
        float totalTime = 0;
        List<QuizTracker.QuizDetails> quiz = holder.quizTracker.quizzes;
        for (int i = 0; i < quiz.Count; i++){
            displayText.text +=
                $"Name: {quiz[i].name}, Time Taken: {quiz[i].timeTaken}, Status: {quiz[i].status.ToString()}\n";
            totalTime += quiz[i].timeTaken;
        }

        displayText.text += $"Total time for quiz = {totalTime}";
    }
}