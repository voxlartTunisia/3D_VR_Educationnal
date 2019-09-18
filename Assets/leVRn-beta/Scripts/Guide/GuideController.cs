using System;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    
    public ScriptableObjectsHolder holder;
    public Transform mainCamera;
    public Transform user;

    public GameObject speechBubble;
    
    [Header("Potential Definition Voice Overs")]
    public AudioClip introduction;
    public AudioClip energyDefinition;
    public AudioClip potentialEnergy;
    public AudioClip potentialContinue;
    public AudioClip potentialPosition;
    public AudioClip potentialBook;
    
    [Header("Potential Examples Voice Overs")]
    public AudioClip streetIntroduction;
    public AudioClip birdExample;
    public AudioClip signpostExample;
    public AudioClip fruitsExample;
    public AudioClip potentialConclusion;
    
    [Header("Kinetic Definition Voice Overs")]
    public AudioClip kineticIntroduction;
    public AudioClip kineticExample;
    public AudioClip kineticConclusion;
    
    [Header("Kinetic Examples Voice Overs")]
    public AudioClip previously;
    public AudioClip busExample;
    public AudioClip pedestrianExample;
    public AudioClip flagExample;
    
    [Header("Quiz Voice Overs")]
    public AudioClip testIntro;
    public AudioClip fruitQuestion;
    public AudioClip fruitRight;
    public AudioClip fruitWrong;
    public AudioClip boxQuestion;
    public AudioClip boxRight;
    public AudioClip boxWrong;
    public AudioClip bikeQuestion;
    public AudioClip bikeRight;
    public AudioClip bikeWrong;
    public AudioClip tankQuestion;
    public AudioClip tankRight;
    public AudioClip tankWrong;
    public AudioClip quizConclusion;

    [Header("Playground Voice Overs")]
    public AudioClip ballSlide;
    public AudioClip guideSlide;
    public AudioClip rockMountain;
    public AudioClip rockConclude;
    public AudioClip fruitPluck;
    public AudioClip stickPluck;
    public AudioClip playgroundConclusion;
    
    
    private Animator anim;
    private float distance;
    [NonSerialized]
    public AudioSource audioSource;

    private static readonly int On = Animator.StringToHash("PowerOn");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int ToScreen = Animator.StringToHash("GestureToScreen");
    private static readonly int Talking = Animator.StringToHash("Talking");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Hit = Animator.StringToHash("Hit");

    [NonSerialized]
    public bool changingLocation;

    // Start is called before the first frame update
    void Awake(){
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        holder.sceneLoader.userLocation = user;
        LookAtUser();
    }

    void Start(){
        ChangeAudioGain();
    }

    public void ChangeLocation(){
        changingLocation = true;
        anim.SetBool(Idle, false);
        anim.SetTrigger(Run);
        Transform guideLocation = holder.propController.guideLocation;
        iTween.MoveTo(transform.parent.gameObject,
            iTween.Hash("position", guideLocation, "speed", 2, "looktarget",
                guideLocation, "oncomplete", nameof(CompleteLocationChange), "oncompletetarget", gameObject, "easetype",
                iTween.EaseType.linear));



    }

    public void CompleteLocationChange(){
        anim.SetBool(Idle, true);
        LookAtUser();
        changingLocation = false;
        ChangeAudioGain();
    }

    void LookAtUser(){
        if (transform.parent != null){
            transform.parent.LookAt(mainCamera,Vector3.up);
        }
        else{
            transform.LookAt(mainCamera,Vector3.up);
        }
        
    }

    public void HitBall(){
        anim.SetTrigger(Hit);
    }

    #region Potential Definition
    
    public void PotentialEnergy(){
        PlayAudio(potentialEnergy);
    }

    public void PotentialContinue(){
        PlayAudio(potentialContinue);
    }

    public void PotentialPosition(){
        PlayAudio(potentialPosition);
    }

    public void PotentialBook(){
        PlayAudio(potentialBook);
    }
    
    #endregion

    #region Potential Examples
    
    public void Introduction(){
        PlayAudio(introduction);
    }

    public void DefineEnergy(){
        PlayAudio(energyDefinition);
    }

    public void StreetIntroduction(){
        PlayAudio(streetIntroduction);
    }

    public void FruitsExample(){
        PlayAudio(fruitsExample);
    }

    public void SignpostExample(){
        PlayAudio(signpostExample);
    }

    public void BirdExample(){
        PlayAudio(birdExample);
    }

    public void PotentialConclusion(){
        PlayAudio(potentialConclusion);
    }
    
    #endregion

    #region Kinetic Definition

    public void KineticIntroduction(){
        PlayAudio(kineticIntroduction);
    }

    public void KineticExample(){
        PlayAudio(kineticExample);
    }

    public void KineticConclusion(){
        PlayAudio(kineticConclusion);
    }
    
    #endregion

    #region Kinetic Examples

    public void Previously(){
        PlayAudio(previously);
    }

    public void BusExample(){
        PlayAudio(busExample);
    }

    public void FlagExample(){
        PlayAudio(flagExample);
    }

    public void PedestrianExample(){
        PlayAudio(pedestrianExample);
    }
    
    #endregion

    #region Quiz

    public void TestIntro(){
        PlayAudio(testIntro);
    }

    public void FruitQuestion(){
        PlayAudio(fruitQuestion);
    }

    public void FruitRight(){
        PlayAudio(fruitRight);
    }

    public void FruitWrong(){
        PlayAudio(fruitWrong);
    }

    public void BoxQuestion(){
        PlayAudio(boxQuestion);
    }

    public void BoxRight(){
        PlayAudio(boxRight);
    }

    public void BoxWrong(){
        PlayAudio(boxWrong);
    }

    public void TankQuestion(){
        PlayAudio(tankQuestion);
    }

    public void TankRight(){
        PlayAudio(tankRight);
    }

    public void TankWrong(){
        PlayAudio(tankWrong);
    }

    public void BikeQuestion(){
        PlayAudio(bikeQuestion);
    }

    public void BikeRight(){
        PlayAudio(bikeRight);
    }

    public void BikeWrong(){
        PlayAudio(bikeWrong);
    }

    public void QuizConclusion(){
        PlayAudio(quizConclusion);
    }
    
    #endregion

    #region Playground

    public void BallSlide(){
        PlayAudio(ballSlide);
    }

    public void GuideSlide(){
        PlayAudio(guideSlide);
    }

    public void RockMountain(){
        PlayAudio(rockMountain);
    }

    public void RockConclude(){
        PlayAudio(rockConclude);
    }

    public void FruitPluck(){
        PlayAudio(fruitPluck);
    }

    public void StickPluck(){
        PlayAudio(stickPluck);
    }

    public void PlaygroundConclusion(){
        PlayAudio(playgroundConclusion);
    }

    #endregion

    private void PlayAudio(AudioClip clip){
        audioSource.PlayOneShot(clip);
        anim.SetBool(Talking,true);
        speechBubble.SetActive(true);
    }

    public void PowerOn(){
        anim.SetTrigger(On);
    }

    public void GestureToScreen(){
        anim.SetTrigger(ToScreen);
    }

    public void DoneTalking(){
        anim.SetBool(Talking, false);
        speechBubble.SetActive(false);
    }

    public void ForceIdle(){
        anim.SetBool(Idle, true);
    }

    private void ChangeAudioGain(){
        distance = Vector3.Distance(user.transform.position, transform.position);
        GetComponentInChildren<ResonanceAudioSource>().gainDb = Mathf.Min(distance*2.5f, 24);
    }
    public void TriggerHitEnded(){
        holder.animationTriggers.HitEnded = true;
    }

    public void TriggerWaveBegun(){
        holder.animationTriggers.WaveBegun = true;
    }

    public void TriggerWaveEnded(){
        holder.animationTriggers.WaveEnded = true;
    }

    public void TriggerPowerOnEnded(){
        holder.animationTriggers.PowerOnEnded = true;
    }
    
    
}
