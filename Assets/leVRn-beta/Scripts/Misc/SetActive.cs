using UnityEngine;

public class SetActive : MonoBehaviour
{
   public void Toggle(){
      gameObject.SetActive(!gameObject.activeSelf);
   }
}
