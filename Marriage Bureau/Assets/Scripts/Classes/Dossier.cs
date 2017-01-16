using UnityEngine;
using System.Collections;
using System;

public class Dossier : MonoBehaviour
{
    protected InteractWithDB dbInteractionScript;
    protected static long dossierID;
    private string username;

    private Person person;
    private Person idealMatch;
    private NotificationList notificationList;
    private RomanticDateList romanticDateList;
    private HoldAndSendLoginValues holdAndSendScript;
    private bool isPremium;

    public string Username
    {
        get
        {
            return username;
        }
    }

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

    protected bool getIsMale()
    {
        return person.getIsMale();
    }

    private void fetchUsername()
    {
        username = holdAndSendScript.Username;
    }

    private void fetchIDFromServer()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchID.php", new string[2] { "id", Username });
    }

    private void fetchIsPremium()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchPremium.php", new string[2] { "premium", "premium" });
    }

    private void fetchNotifications()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchNotifications.php", new string[2] { "username", Username });
    }

    private IEnumerator gatherInformation()
    {
        fetchUsername();
        fetchIDFromServer();
        while (dbInteractionScript.IsRequesting)
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
        gatherInformation();
    }

    public Dossier(long newDossierID, bool newIsPremium, Person newPerson)
    {
        dossierID = newDossierID;
        isPremium = newIsPremium;
        person = newPerson;
    }

    private void Start()
    {
        GameObject holderOfValues = GameObject.Find("HolderOfValues");
        dbInteractionScript = holderOfValues.GetComponent<InteractWithDB>();
        holdAndSendScript = holderOfValues.GetComponent<HoldAndSendLoginValues>();
    }
}
