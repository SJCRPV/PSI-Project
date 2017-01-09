using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitInput : MonoBehaviour {
    [SerializeField]
    private string destinationURL = "http://psiwebservice/SubmitInput.php"; 
    [SerializeField]
    private string[] varNames;
    [SerializeField]
    private string[] varValues;
    [SerializeField]
    private string tableName;

    private InputField nameField;
    private InputField emailField;
    private InputField usernameField;
    private InputField passwordField;
    private InputField confirmPassField;
    //private InteractWithDB interactDBScript;
    private StaticScript staticScript;

    //TODO: The Register page, as it is, is not exactly compatible with how things are set up in the DB. Have it insert password and username and save the other values for later.
    public void gatherInput()
    {
        varValues[0] = nameField.text;
        varValues[1] = emailField.text;
        varValues[2] = usernameField.text;
        //TODO: Look into hashing these if you have the time;
        varValues[3] = passwordField.text;
        if (varValues[3] == confirmPassField.text)
        {
            //interactDBScript.sendToDB(destinationURL, varNames, varValues);
            staticScript.DestinationURL = destinationURL;
            staticScript.VarNames = varNames;
            staticScript.VarValues = varValues;
            staticScript.DbTable = tableName;
            staticScript.sendToDB();
        }
        else
        {
            //TODO: Runtime message telling you the passwords don't match
            Debug.LogError("The passwords don't match");
        }
    }

	// Use this for initialization
	void Start () {
        //TODO: Find way of assigning these variables in a generic way so you don't have to hardcode it
        nameField = GameObject.Find("NomeInputField").GetComponent<InputField>();
        emailField = GameObject.Find("EmailInputField").GetComponent<InputField>();
        usernameField = GameObject.Find("UsernameInputField").GetComponent<InputField>();
        passwordField = GameObject.Find("PasswordInputField").GetComponent<InputField>();
        confirmPassField = GameObject.Find("ConfirmPassInputField").GetComponent<InputField>();
        //interactDBScript = GetComponent<InteractWithDB>();
        staticScript = GameObject.Find("HolderOfValues").GetComponent<StaticScript>();
        //varNames = new string[] { "Name", "Email", "Username", "Password"};
        varValues = new string[varNames.Length];
    }
}
