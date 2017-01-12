using UnityEngine;
using System.Collections;
using System;

public class Dossier
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
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchID.php", new string[2] { "id", userScript.Username });
    }

    private void fetchIsPremium()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchPremium.php", new string[2] { "premium", "premium" });
    }

    private void fetchNotifications()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchNotifications.php", new string[2] { "username", userScript.Username });
    }

    private IEnumerator gatherInformation()
    {
        fetchIDFromServer();
        while(dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        dossierID = Convert.ToInt64(dbInteractionScript.CleanData[0]);

        fetchIsPremium();
        while(dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        isPremium = Convert.ToBoolean(dbInteractionScript.CleanData[0]);

        fetchNotifications();
        while(dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
    }

    protected Dossier()
    {
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        userScript = GameObject.Find("HolderOfValues").GetComponent<User>();
        gatherInformation();
    }

    public Dossier(long newDossierID, bool newIsPremium, Person newPerson)
    {
        dossierID = newDossierID;
        isPremium = newIsPremium;
        person = newPerson;
    }
}
