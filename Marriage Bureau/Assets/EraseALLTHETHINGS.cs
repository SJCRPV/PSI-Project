using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EraseALLTHETHINGS : MonoBehaviour {
    public InputField inputText;

    public void eraseText()
    {
        inputText.text = "";
    }

	// Use this for initialization
	void Start () {
        inputText = GameObject.Find("inp_Name").GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
