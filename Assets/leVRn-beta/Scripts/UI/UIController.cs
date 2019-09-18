using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    
    [SerializeField]
    private GameObject learn;

    
    [SerializeField]
    private GameObject screen;

    [SerializeField] private TextMeshProUGUI screenText;

    [SerializeField] 
    private GameObject workHolder;

    [SerializeField] 
    private GameObject restHolder;

    [SerializeField] private GameObject movingHolder;
    private static readonly int Vanish = Animator.StringToHash("Vanish");
    // Start is called before the first frame update

    public void ActivateScreen(){
        screen.SetActive(true);
    }

    public void DisplayOnScreen(string message){
        screenText.text = message;
    }

    public void RemoveTitle(){
        title.GetComponent<Animator>().SetTrigger(Vanish);
    }

    public void ToggleLearn(){
        learn.SetActive(!learn.activeSelf);
    }

    public void ToggleWork(){
        workHolder.SetActive(!workHolder.activeSelf);
    }
    
    public void ToggleRest(){
        restHolder.SetActive(!restHolder.activeSelf);
    }

    public void ToggleMoving(){
        movingHolder.SetActive(!movingHolder.activeSelf);
    }

    
    
}
