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
    static string[][] conditionValues;
    static bool isMonthlyPremium;

    private InteractWithDB dbInteractionScript;

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public string DbTable
    {
        get
        {
            return dbTable;
        }

        set
        {
            dbTable = value;
        }
    }

    public string DestinationURL
    {
        get
        {
            return destinationURL;
        }

        set
        {
            destinationURL = value;
        }
    }

    public string[] VarNames
    {
        get
        {
            return varNames;
        }

        set
        {
            varNames = value;
        }
    }

    public string[] VarValues
    {
        get
        {
            return varValues;
        }

        set
        {
            varValues = value;
        }
    }

    public bool IsMonthlyPremium
    {
        get
        {
            return isMonthlyPremium;
        }

        set
        {
            isMonthlyPremium = value;
        }
    }

    public void fetchLoginValues()
    {
        Username = GameObject.Find("Username").GetComponent<InputField>().text;
        Password = GameObject.Find("Password").GetComponent<InputField>().text;
    }

    public void clearValues()
    {
        Username = "";
        Password = "";
        DbTable = "";
        DestinationURL = "";
        VarNames = null;
        VarValues = null;
    }

    //public void setCurrentTable(string tableName)
    //{
    //    DbTable = tableName;
    //}

    //public void setDestinationURL(string url)
    //{
    //    DestinationURL = url;
    //}

    //public void setVarNames(string[] newVarNames)
    //{
    //    VarNames = newVarNames;
    //}

    //public void setVarValues(string[] newVarValues)
    //{
    //    VarValues = newVarValues;
    //}

    //public void setIsMonthlyPremium(bool newBool)
    //{
    //    IsMonthlyPremium = newBool;
    //}

    public void sendToDB()
    {
        dbInteractionScript.sendToDB(DestinationURL, VarNames, VarValues, DbTable);
    }

    public string[] getFromDB()
    {
        return dbInteractionScript.getFromDB(DestinationURL);
    }

    public string[] getSelectFromDB()
    {
        return dbInteractionScript.getSelectFromDB(DestinationURL, VarNames, DbTable);
    }

    // Use this for initialization
    void Start () {
        dbInteractionScript = GetComponent<InteractWithDB>();
	}
}
