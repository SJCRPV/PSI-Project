using UnityEngine;
using System.Collections;

public abstract class Dossier : MonoBehaviour
{
    private static long dossierID;
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

    private long fetchIDFromServer()
    {
        //TODO: interface with the DB to fetch the dossier ID associated with the user
        return -1;
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
        dossierID = fetchIDFromServer();
        person = GetComponent<Person>();
        isPremium = fetchIsPremium();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
