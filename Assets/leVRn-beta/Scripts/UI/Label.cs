using UnityEngine;

public class Label : MonoBehaviour
{

    public Transform mainCamera;
    void Start()
    {
        LookAtUser();
    }

    void Update(){
        LookAtUser();
    }

    void LookAtUser(){
        transform.LookAt(mainCamera, Vector3.up);
        transform.Rotate(0,180,0);
    }
}
