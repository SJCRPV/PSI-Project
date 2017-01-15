using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimitedProfile : Dossier {

    private Text text;
    private SpriteRenderer profileImage;
    private long originDossierID;
    private string profileName;
    private string district;
    private bool isMale;
    private int age;
    private string[] abridgedPreferences;
    
    private void displayText()
    {
        string tmp = "Nome: " + profileName + "\nLocalização: " + district + "\nIdade: " + age + "\nPreferências: ";
        for(int i = 0; i < abridgedPreferences.Length; i+= 2)
        {
            tmp += abridgedPreferences[i] + ", " + abridgedPreferences[i + 1] + "\n";
        }
        text.text = tmp;
    }

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

    private bool findIfMale()
    {
        return getIsMale();
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
        displayText();
    }

	// Use this for initialization
	void Start () {
        text = gameObject.transform.GetChild(0).GetComponentInChildren<Text>();
        profileImage = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        fetchProfileInfo();
	}
}
