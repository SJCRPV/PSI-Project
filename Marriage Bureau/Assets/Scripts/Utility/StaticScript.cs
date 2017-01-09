using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticScript : MonoBehaviour {

    public string[] cleanData;

    static string username;
    static string password;
    static string dbTable;
    static string destinationURL;
    static string[] varNames;
    static string[] varValues;
    static string[][] conditionValues;
    static bool isMonthlyPremium;

    private InteractWithDB dbInteractionScript;
    private Object callingObject;
    private bool hasRun;

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
        hasRun = false;
    }

    public void getFromDB()
    {
        dbInteractionScript.getFromDB(DestinationURL);
        hasRun = false;
    }

    public void getSelectFromDB()
    {
        dbInteractionScript.getSelectFromDB(DestinationURL, VarNames, DbTable);
        hasRun = false;
    }

    // Use this for initialization
    void Start () {
        dbInteractionScript = GetComponent<InteractWithDB>();
	}

    private void Update()
    {
        if(!dbInteractionScript.isWWWRequesting() && !hasRun)
        {
            cleanData = dbInteractionScript.getCleanData();
            hasRun = true;
        }
    }
}