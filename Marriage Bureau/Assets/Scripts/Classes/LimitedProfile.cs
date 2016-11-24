using UnityEngine;
using System.Collections;

public class LimitedProfile : Dossier {

    private long originDossierID;
    private string profileName;
    private string district;
    private int age;
    private string[] abridgedPreferences;
    
    private string findFirstName()
    {
        string[] firstName = getDossierName().Split(' ');
        return firstName[0];
    }

    private string findDistrict()
    {
        string[] possibleDistrict = getDossierAddress().Split(' ');
        return possibleDistrict[possibleDistrict.Length];
    }

    private string[] findAbridgedPreferences()
    {
        string[] temp = getDossierPreferences();
        string[] abridged = new string[temp.Length];
        for(int i = 0; i < temp.Length; i++)
        {
            abridged[i] = temp[i].Remove(temp[i].IndexOf("-"));
        }

        return abridged;
    }

    private void fetchProfileInfo()
    {
        originDossierID = getDossierID();
        profileName = findFirstName();
        district = findDistrict();
        age = getDossierAge();
        abridgedPreferences = findAbridgedPreferences();
    }

	// Use this for initialization
	void Start () {
        fetchProfileInfo();
	}
}
