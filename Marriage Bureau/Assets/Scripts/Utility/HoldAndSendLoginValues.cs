using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldAndSendLoginValues : MonoBehaviour {

    private InputField usernameField;
    private InputField passwordField;
    private InteractWithDB dbInteractionScript;
    private string username;
    private string password;

    public string Username
    {
        get
        {
            return username;
        }
    }

    public void verifyCredentials()
    {
        //TODO: Hash password if you have the time
        string[] varNames = { "username", "password" };
        string[] varValues = { username, password };
        dbInteractionScript.sendToDB("http://psiwebservice/verifyCredentials.php", varNames, varValues);
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
	}
}
