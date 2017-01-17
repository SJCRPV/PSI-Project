using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitInput : MonoBehaviour {
    [SerializeField]
    private string[] varNames;
    [SerializeField]
    private string[] varValues;

    private string destinationURL = "http://psiwebservice/SubmitInput.php"; 
    private InputField nameField;
    private InputField emailField;
    private InputField usernameField;
    private InputField passwordField;
    private InputField confirmPassField;
    private InteractWithDB interactDBScript;
    private ButtonPress buttonPressScript;

    //TODO: The Register page, as it is, is not exactly compatible with how things are set up in the DB. Have it insert password and username and save the other values for later.
    private IEnumerator sendToDB()
    {
        interactDBScript.sendToDB(destinationURL, varNames, varValues);
        while (interactDBScript.IsRequesting)
        {
            yield return null;
        }
        Debug.Log(interactDBScript.CleanData);
        buttonPressScript.loadScene();
    }

    public void gatherInput()
    {
        varValues[0] = nameField.text;
        varValues[1] = emailField.text;
        varValues[2] = usernameField.text;
        //TODO: Look into hashing these if you have the time;
        varValues[3] = passwordField.text;
        if (varValues[3].Equals(confirmPassField.text))
        {
            StartCoroutine(sendToDB());
        }
        else
        {
            //TODO: Runtime message telling you the passwords don't match
            Debug.LogError("The passwords don't match");
        }
    }

	// Use this for initialization
	void Start () {
        nameField = GameObject.Find("NomeInputField").GetComponent<InputField>();
        emailField = GameObject.Find("EmailInputField").GetComponent<InputField>();
        usernameField = GameObject.Find("UsernameInputField").GetComponent<InputField>();
        passwordField = GameObject.Find("PasswordInputField").GetComponent<InputField>();
        confirmPassField = GameObject.Find("ConfirmPassInputField").GetComponent<InputField>();
        interactDBScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        buttonPressScript = GetComponent<ButtonPress>();
        varValues = new string[varNames.Length];
    }
}
