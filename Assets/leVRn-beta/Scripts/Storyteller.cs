using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAsync;

public class Storyteller : MonoBehaviour
{
    public ScriptableObjectsHolder holder;
    public GuideController guide;
    public UIController ui;

    private float shortBreak = 0.5f;
    private float longBreak = 2f;

    /*private void Awake(){
        DontDestroyOnLoad(gameObject);
    }*/

    private void Start(){
        if (holder.phase == 0)
            BeginIntroduction();
        else if (holder.phase == 1)
            IntroduceStreet();
        else if (holder.phase == 2){
            IntroduceKineticEnergy();
        }
        else if (holder.phase == 3){
            IntroduceKineticStreet();
        }
        else if (holder.phase == 4){
            IntroduceTest();
        }
        else if (holder.phase == 5){
            IntroduceField();
        }
    }

    public void SetActive(GameObject element){
        element.SetActive(!element.activeSelf);
    }

    #region PotentialDefinition

    async void BeginIntroduction(){
        await new UnityAsync.WaitUntil((() => holder.animationTriggers.WaveBegun));
        holder.animationTriggers.WaveBegun = false;
        guide.Introduction();
        DefineEnergy();
    }

    async void DefineEnergy(){
        RemoveTitle();
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ActivateScreen();
        ui.DisplayOnScreen("Energy is the ability to do <size=300><color=black>work</color></size>");
        guide.GestureToScreen();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.DefineEnergy();
        PotentialEnergy();
    }

    

    async void PotentialEnergy(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ToggleWork();
        await new UnityAsync.WaitForSeconds(longBreak);
        ui.ToggleWork();
        ui.DisplayOnScreen("Potential energy is the energy stored by a body at <size=300><color=black>rest</color></size>");
        guide.GestureToScreen();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.PotentialEnergy();
        PotentialEnergyContinue();
    }

    async void PotentialEnergyContinue(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ToggleRest();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.PotentialContinue();
        PotentialPosition();
    }

    async void PotentialPosition(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        ui.ToggleRest();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.PotentialPosition();
        ui.DisplayOnScreen("Potential energy is also the energy a body has because of its <size=300><color=black>position</color></size>");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.GestureToScreen();
        PotentialBook();
    }

    async void PotentialBook(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.PotentialBook();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.propController.ActivateBookExample();
        GoToStreet();
    }

    async void GoToStreet(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.phase = 1;
        holder.sceneLoader.LoadStreetScene();
    }
        
    #endregion

    #region Potential Examples
    async void IntroduceStreet(){
        guide.ForceIdle();
        await new UnityAsync.WaitForSeconds(longBreak);
        guide.StreetIntroduction();
        SignpostExample();
    }

    async void SignpostExample(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.SignpostExample();
        holder.propController.HighlightProp("Signpost");
        BirdExample();
    }

    async void BirdExample(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.UnhighlightProp("Signpost");
        holder.propController.PlayDefaultAudio("Bird");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.BirdExample();
        holder.propController.HighlightProp("Bird");
        FruitsExample();
    }
    
    async void FruitsExample(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.UnhighlightProp("Bird");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.FruitsExample();
        holder.propController.HighlightProp("Fruits");
        PotentialConclusion();
    }

    async void PotentialConclusion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.UnhighlightProp("Fruits");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.PotentialConclusion();
        GoBackToSimulationRoom();
    }
    
    async void GoBackToSimulationRoom(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.phase = 2;
        holder.sceneLoader.LoadSimulationScene();       
    }
    
    
    #endregion
    
    #region Kinetic Definition

    async void IntroduceKineticEnergy(){
        guide.ForceIdle();
        ui.ToggleLearn();
        ui.RemoveTitle();
        await new UnityAsync.WaitForSeconds(longBreak);
        guide.KineticIntroduction();
        ui.ActivateScreen();
        ui.DisplayOnScreen("Kinetic Energy is the energy possessed by a <size=300><color=black>moving</color></size> body. ");
        KineticExample();
    }

    async void KineticExample(){       
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        ui.ToggleMoving();
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(longBreak);
        ui.ToggleMoving();
        guide.KineticExample();
        holder.propController.ActivateBall();
                
        PlayBallHit();
        KineticConclusion();
    }

    async void KineticConclusion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.KineticConclusion();
        GoToKinetic();
    }

    async void GoToKinetic(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.phase = 3;
        holder.sceneLoader.LoadKineticStreetScene();
    }
    
    
    #endregion
    
    #region Kinetic Examples

    async void IntroduceKineticStreet(){
        guide.ForceIdle();
        await new UnityAsync.WaitForSeconds(longBreak);
        guide.Previously();
        BusExample();
    }

    async void BusExample(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.BusExample();
        holder.propController.HighlightProp("Bus");
        holder.propController.DefaultAnimation("Bus");
        holder.propController.PlayDefaultAudio("Bus");
        PedestrianExample();
    }

    async void PedestrianExample(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(longBreak + 2);
        guide.PedestrianExample();
        holder.propController.UnhighlightProp("Bus");
        holder.propController.HighlightProp("Pedestrian");
        holder.propController.DefaultAnimation("Pedestrian");
        FlagExample();
    }

    async void FlagExample(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(longBreak + 3);
        holder.propController.UnhighlightProp("Pedestrian");
        holder.propController.SetGuideLocation("Flag");
        guide.ChangeLocation();
        await new UnityAsync.WaitUntil((() => !guide.changingLocation));
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.FlagExample();      
        holder.propController.HighlightProp("Flag");
        GoToTest();
    }

    async void GoToTest(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.phase = 4;
        holder.sceneLoader.LoadStreetTestScene();
    }
    
    
    #endregion
    
    #region Quiz

    async void IntroduceTest(){
        guide.ForceIdle();
        await new UnityAsync.WaitForSeconds(longBreak);
        guide.TestIntro(); 
        FruitQuestion();
    }

    async void FruitQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.SetGuideLocation("Tree");
        guide.ChangeLocation();
        await new UnityAsync.WaitUntil((() => !guide.changingLocation));
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.FruitQuestion();
        holder.propController.HighlightProp("Tree");
        DisplayFruitQuestion();
    }

    async void DisplayFruitQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Tree");
        AnswerFruitQuestion();
    }

    async void AnswerFruitQuestion(){
        await new UnityAsync.WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        PropController.Answer answer = holder.propController.answer;
        if (answer == PropController.Answer.Right){
            guide.FruitRight();
        }
        else{
            guide.FruitWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        BikeQuestion();
    }

    async void BikeQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.RemoveQuestion("Tree");
        holder.propController.UnhighlightProp("Tree");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.BikeQuestion();
        holder.propController.HighlightProp("Bike");
        holder.propController.PlayDefaultAudio("Bike");
        holder.propController.DefaultAnimation("Bike");
        DisplayBikeQuestion();
    }

    async void DisplayBikeQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Bike");
        AnswerBikeQuestion();
    }

    async void AnswerBikeQuestion(){
        await new UnityAsync.WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        if (holder.propController.answer == PropController.Answer.Right){
            guide.BikeRight();
        }
        else{
            guide.BikeWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        TankQuestion();
    }

    async void TankQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.RemoveQuestion("Bike");
        holder.propController.UnhighlightProp("Bike");
        holder.propController.SetGuideLocation("Box");
        guide.ChangeLocation();
        await new UnityAsync.WaitUntil((() => !guide.changingLocation));
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.TankQuestion();
        holder.propController.HighlightProp("Tank");
        DisplayTankQuestion();
    }

    async void DisplayTankQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Tank");
        AnswerTankQuestion();
    }

    async void AnswerTankQuestion(){
        await new UnityAsync.WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        if (holder.propController.answer == PropController.Answer.Right){
            guide.TankRight();
        }
        else{
            guide.TankWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        BoxQuestion();
    }

    async void BoxQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.RemoveQuestion("Tank");
        holder.propController.UnhighlightProp("Tank");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.BoxQuestion();
        holder.propController.HighlightProp("Box");
        DisplayBoxQuestion();
    }

    async void DisplayBoxQuestion(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.DisplayQuestion("Box");
        AnswerBoxQuestion();
    }

    async void AnswerBoxQuestion(){
        await new UnityAsync.WaitUntil((() => holder.propController.answer != PropController.Answer.Unanswered));
        if (holder.propController.answer == PropController.Answer.Right){
            guide.BoxRight();
        }
        else{
            guide.BoxWrong();
        }

        holder.propController.answer = PropController.Answer.Unanswered;
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.QuizConclusion();
        GoToField();
        Debug.Log("Something happen rn");
        //Instantiate(holder.quizTracker.experienceStats);
    }

    async void GoToField(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.phase = 5;
        holder.sceneLoader.LoadField();
    }
    
    
    #endregion
    
    #region Field

    async void IntroduceField(){
        guide.ForceIdle();
        await new UnityAsync.WaitForSeconds(longBreak);
        guide.BallSlide();
        BallSlide();
    }

    async void BallSlide(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        holder.propController.TurnOffKinematic("SlideBall");
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.GuideSlide();
        GuideSlide();
    }

    async void GuideSlide(){
        await new UnityAsync.WaitUntil((() => !guide.audioSource.isPlaying));
        guide.DoneTalking();
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.propController.SetGuideLocation("Slide");
        guide.ChangeLocation();
        await new UnityAsync.WaitUntil((() => !guide.changingLocation));
        await new UnityAsync.WaitForSeconds(shortBreak);
        holder.propController.SetGuideLocation("Mountain");
        guide.ChangeLocation();
        await new UnityAsync.WaitUntil((() => !guide.changingLocation));
        await new UnityAsync.WaitForSeconds(shortBreak);
        guide.RockMountain();
    }
    
    #endregion
    
    async void RemoveTitle(){
        await new UnityAsync.WaitForSeconds(4f);
        ui.RemoveTitle();
    }

    async void PlayBallHit(){
        await new UnityAsync.WaitForSeconds(2);
        guide.HitBall();
        await new UnityAsync.WaitUntil((() => holder.animationTriggers.HitEnded));
        holder.animationTriggers.HitEnded = false;
        holder.propController.PlayDefaultAudio("Ball");
    }

    private void OnApplicationQuit(){
        holder.phase = 0;
    }
}
