
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAsync;

[CreateAssetMenu(fileName = "SceneLoader", menuName = "Misc/SceneLoader")]
public class SceneLoader : ScriptableObject
{
    public int mainScene;
    public int streetScene;
    public int kineticStreet;
    public int streetTest;
    public int field;
    public GameObject loadingSphere;

    [NonSerialized] public Transform userLocation;

    public async void LoadStreetScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(streetScene, LoadSceneMode.Single);
        await new UnityAsync.WaitUntil((() => asyncLoad.isDone));
    }
    
    public async void LoadSimulationScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainScene, LoadSceneMode.Single);
        await new UnityAsync.WaitUntil((() => asyncLoad.isDone));
    }

    public async void LoadKineticStreetScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(kineticStreet, LoadSceneMode.Single);
        await new UnityAsync.WaitUntil((() => asyncLoad.isDone));
    }
    
    public async void LoadStreetTestScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(streetTest, LoadSceneMode.Single);
        await new UnityAsync.WaitUntil((() => asyncLoad.isDone));
    }

    public async void LoadField(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(field, LoadSceneMode.Single);
        await new UnityAsync.WaitUntil((() => asyncLoad.isDone));
    }
}
