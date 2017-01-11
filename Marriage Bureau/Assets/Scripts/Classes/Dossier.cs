using UnityEngine;
using System.Collections;
using System;

public class Dossier : MonoBehaviour
{

    protected InteractWithDB dbInteractionScript;
    protected User userScript;
    protected static long dossierID;

    private Person person;
    private Person idealMatch;
    private NotificationList notificationList;
    private RomanticDateList romanticDateList;
    private bool isPremium;

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
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchID.php", new string[] { "id", userScript.Username });
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
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        userScript = GameObject.Find("HolderOfValues").GetComponent<User>();
        StartCoroutine(gatherInformation());
    }
}
