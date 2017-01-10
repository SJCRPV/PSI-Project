using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Person : Dossier {

    private Personality personality;
    private string fullName;
    private bool sex;
    private int age;
    private string address;
    private string profilePhoto;

    public string getName()
    {
        return fullName;
    }
    public string getAddress()
    {
        return address;
    }
    public int getAge()
    {
        return age;
    }
    public bool isMale()
    {
        return sex;
    }
    public string getProfilePhotoDir()
    {
        return profilePhoto;
    }
    public string[] getPreferences()
    {
        List<PersonalLike> temp = personality.getPreferences();
        string[] tmpStr = new string[temp.Count];
        for(int i = 0; i < tmpStr.Length; i++)
        {
            tmpStr[i] = temp[i].toString();
        }
        return tmpStr;
    }

    private IEnumerator fetchPersonFromServer()
    {
        string dossierID = Convert.ToString(getDossierID());
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchPerson.php", new string[] { "IDPESSOA", dossierID });
        if(dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        else
        {

        }
    }

	// Use this for initialization
	void Start () {
        fetchPersonFromServer();
	}
}
