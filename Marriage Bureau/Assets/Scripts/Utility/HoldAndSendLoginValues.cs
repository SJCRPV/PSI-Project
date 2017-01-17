using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldAndSendLoginValues : MonoBehaviour {

    private InputField usernameField;
    private InputField passwordField;
    private InteractWithDB dbInteractionScript;
    private ButtonPress buttonPressScript;
    private string username;
    private string password;

    public string Username
    {
        get
        {
            return username;
        }
    }

    public IEnumerator verifyingCredentials()
    {
        //TODO: Hash password if you have the time
        string[] varNames = { "username", "password" };
        string[] varValues = { username, password };
        dbInteractionScript.sendToDB("http://psiwebservice/verifyCredentials.php", varNames, varValues);
        while (dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        string temp = dbInteractionScript.CleanData[0];
        if (temp.Equals("true"))
        {
            buttonPressScript.loadScene();
        }
    }

    public void callForCredentialVerification()
    {
        StartCoroutine(verifyingCredentials());
    }

    public void gatherLoginValues()
    {
        username = usernameField.text;
        password = passwordField.text;
    }

    public void gatherRegisterUsername()
    {
        username = GameObject.Find("UsernameInputField").GetComponent<InputField>().text;
    }

	// Use this for initialization
	void Start () {
        dbInteractionScript = GetComponent<InteractWithDB>();
        usernameField = GameObject.Find("Username").GetComponent<InputField>();
        passwordField = GameObject.Find("Password").GetComponent<InputField>();
        buttonPressScript = GameObject.Find("Login").GetComponent<ButtonPress>();
	}
}
