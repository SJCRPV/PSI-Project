using UnityEngine;
using System.Collections;

public class Dossier : MonoBehaviour {

    private static long dossierID;
    private Person person;
    private Person idealMatch;
    private NotificationList notificationList;
    private RomanticDateList romanticDateList;
    private bool isPremium;

    public long getDossierID()
    {
        return dossierID;
    }
    public string getDossierName()
    {
        return person.getName();
    }
    public string getDossierAddress()
    {
        return person.getAddress();
    }
    public int getDossierAge()
    {
        return person.getAge();
    }
    public string[] getDossierPreferences()
    {
        return person.getPreferences();
    }


	// Use this for initialization
	void Start () {
        //This will fill in the information by fecthing it from the database
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
