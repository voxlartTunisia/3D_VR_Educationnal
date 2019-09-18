using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWord : MonoBehaviour
{
    private MeshRenderer rend;

    private static readonly int Emission = Shader.PropertyToID("_EmissionColor");

    // Start is called before the first frame update
    void Start(){
        rend = GetComponent<MeshRenderer>();
        ChangeColour();
    }

    // Update is called once per frame

    void ChangeColour(){
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        rend.material.color = color;
        rend.material.SetColor(Emission, color * 0.5f);
    }
}
