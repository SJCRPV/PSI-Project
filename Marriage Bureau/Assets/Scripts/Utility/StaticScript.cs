using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticScript : MonoBehaviour {

    static string username;
    static string password;
    static string dbTable;
    static string destinationURL;
    static string[] varNames;
    static string[] varValues;
    static bool isMonthlyPremium;

    private InteractWithDB dbInteractionScript;

    public void getLoginValues()
    {
        username = GameObject.Find("Username").GetComponent<InputField>().text;
        password = GameObject.Find("Password").GetComponent<InputField>().text;
    }

    public void clearValues()
    {
        username = "";
        password = "";
        dbTable = "";
        destinationURL = "";
        varNames = null;
        varValues = null;
    }

    public void setCurrentTable(string tableName)
    {
        dbTable = tableName;
    }

    public void setDestinationURL(string url)
    {
        destinationURL = url;
    }

    public void setVarNames(string[] newVarNames)
    {
        varNames = newVarNames;
    }

    public void setVarValues(string[] newVarValues)
    {
        varValues = newVarValues;
    }

    public void setIsMonthlyPremium(bool newBool)
    {
        isMonthlyPremium = newBool;
    }

    public void sendToDB()
    {
        dbInteractionScript.sendToDB(destinationURL, varNames, varValues, dbTable);
    }

    public void getFromDB()
    {
        dbInteractionScript.getFromDB(destinationURL);
    }

    public void getSelectFromDB()
    {
        dbInteractionScript.getSelectFromDB(destinationURL, varNames, dbTable);
    }

    // Use this for initialization
    void Start () {
        dbInteractionScript = GetComponent<InteractWithDB>();
	}
}
