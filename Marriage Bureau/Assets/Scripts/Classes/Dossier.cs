using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class Dossier : MonoBehaviour
{

    private static long dossierID;
    private bool isPremium;
    private int runFunctionID;
    private StaticScript staticScript;
    private Person person;
    private Person idealMatch;
    private NotificationList notificationList;
    private RomanticDateList romanticDateList;
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

    private void fetchIDFromServer()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchID.php", new string[] { "id", staticScript.Username });
    }

    private void fetchIsPremium()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchPremium.php", new string[] { "premium", "premium" });
    }

    private IEnumerator gatherInformation()
    {
        fetchIDFromServer();
        if(!dbInteractionScript.IsRequesting)
        {
            dossierID = Convert.ToInt64(dbInteractionScript.CleanData[0]);
        }
        else
        {
            yield return null;
        }

        fetchIsPremium();
        if(!dbInteractionScript.IsRequesting)
        {
            isPremium = Convert.ToBoolean(dbInteractionScript.CleanData[0]);
        }
        else
        {
            yield return null;
        }
    }

    // Use this for initialization
    void Start()
    {
        //This will fill in the information by fecthing it from the database
        staticScript = GameObject.Find("HolderOfValues").GetComponent<StaticScript>();
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        StartCoroutine(gatherInformation());
    }
}
