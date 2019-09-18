using System;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    public Transform mainCamera;
    [SerializeField]
    private Answer answer;

    public string name;
    public Color right, wrong;

    public GameObject correct;

    public Image optionA, optionB;
    
    enum Answer{OptionA, OptionB}

    private float initialTime;
    // Start is called before the first frame update
    void Start()
    {
        LookAtUser();
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LookAtUser(){
        transform.LookAt(mainCamera, Vector3.up);
        transform.Rotate(0,180,0);
    }

    public void ClickedOptionA(Button self){
        self.interactable = false;
        if (answer == Answer.OptionA){
            RightAnswer();
        }
        else{
            WrongAnswer();
        }
    }

    public void ClickedOptionB(Button self){
        self.interactable = false;
        if (answer == Answer.OptionB){
            RightAnswer();
        }
        else{
            WrongAnswer();
        }
    }

    private void RightAnswer(){
        correct.SetActive(true);
        holder.propController.answer = PropController.Answer.Right;
        holder.quizTracker.quizzes.Add(new QuizTracker.QuizDetails(name,Time.time - initialTime, QuizTracker.QuizDetails.Status.PASS));
    }

    private void WrongAnswer(){
        if (answer == Answer.OptionA){
            optionA.color = right;
            optionB.color = wrong;
        }
        else{
            optionA.color = wrong;
            optionB.color = right;
        }

        holder.propController.answer = PropController.Answer.Wrong;
        holder.quizTracker.quizzes.Add(new QuizTracker.QuizDetails(name,Time.time - initialTime, QuizTracker.QuizDetails.Status.FAILED));

    }
}
