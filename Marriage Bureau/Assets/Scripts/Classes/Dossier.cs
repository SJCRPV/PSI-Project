using UnityEngine;
using System.Collections;
using System;

public class Dossier : MonoBehaviour
{

    private StaticScript staticScript;
    private static long dossierID;
    private Person person;
    private Person idealMatch;
    private NotificationList notificationList;
    private RomanticDateList romanticDateList;
    private bool isPremium;

    private InteractWithDB dbInteractionScript;

    protected long getDossierID()
    {
        return dossierID;
    }
    protected string getDossierName()
    {
        return person.getName();
    }
    protected string getDossierAddress()
    {
        return person.getAddress();
    }
    protected int getDossierAge()
    {
        return person.getAge();
    }
    protected string[] getDossierPreferences()
    {
        return person.getPreferences();
    }

    private long fetchIDFromServers()
    {
        //TODO: Interface with the DB to fetch the dossier ID associated with the user
        staticScript.DestinationURL = "http://psiwebservice/fetchID.php";
        staticScript.DbTable = "pessoa";
        staticScript.VarNames = new string[] { "id", staticScript.Username };
        long returnID = Convert.ToInt64(staticScript.getSelectFromDB()[0]);
        return returnID;
    }

    private void fetchIDFromServer(out long returnID)
    {
        dbInteractionScript.getSelectFromDB("http://psiwebservice/fetchID.php", new string[] { "id", staticScript.Username }, "pessoa", out long returnID);
        returnID = -1;
    }

    private bool fetchIsPremium()
    {
        //TODO: Interface with the DB to check if the dossier is tied to a premium account
        return false;
    }

    // Use this for initialization
    void Start()
    {
        //This will fill in the information by fecthing it from the database
        staticScript = GameObject.Find("HolderOfValues").GetComponent<StaticScript>();
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        dossierID = fetchIDFromServers();
        person = GetComponent<Person>();
        isPremium = fetchIsPremium();
    }
}
