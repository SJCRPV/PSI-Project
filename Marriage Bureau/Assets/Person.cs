using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour {

    private Personality personality;
    private string fullName;
    private bool sex;
    private int age;
    private float height;
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
    public float getHeight()
    {
        return height;
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
