using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeInteractable : MonoBehaviour {

    public InputField inputData;
    public InputField inputHora;
    public InputField inputLocal; 

    public void onClick()
    {
        inputData.interactable = !inputData.interactable;
        inputHora.interactable = !inputHora.interactable;
        inputLocal.interactable = !inputLocal.interactable;
    }
}
