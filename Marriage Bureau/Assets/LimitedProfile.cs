using UnityEngine;
using System.Collections;

public class LimitedProfile : MonoBehaviour {

    private Dossier dossier;
    private long originDossierID;
    private string profileName;
    private string district;
    private int age;
    private string[] abridgedPreferences;

    private long getDossierID()
    {
        return dossier.getDossierID();
    }
    
    private string findFirstName()
    {
        string[] firstName = dossier.getDossierName().Split(' ');
        return firstName[0];
    }

    private string findDistrict()
    {
        string[] possibleDistrict = dossier.getDossierAddress().Split(' ');
        return possibleDistrict[possibleDistrict.Length];
    }

    private int findAge()
    {
        return dossier.getDossierAge();
    }

    private string[] findAbridgedPreferences()
    {
        string[] temp = dossier.getDossierPreferences();
        string abridged = "";
        for(int i = 0; i < temp.Length; i++)
        {
            abridged += temp[i];
        }

        return new string[1];
    }

    private void fetchProfileInfo()
    {
        originDossierID = getDossierID();
        profileName = findFirstName();
        district = findDistrict();
        age = findAge();
        abridgedPreferences = findAbridgedPreferences();
    }

	// Use this for initialization
	void Start () {
        fetchProfileInfo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
