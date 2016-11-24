using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Personality : MonoBehaviour {

    private PersonalLike traits;
    private PersonalLike films;
    private PersonalLike colours;
    private PersonalLike songs;
    private List<PersonalLike> extras;

    public List<PersonalLike> getPreferences()
    {
        List<PersonalLike> temp = new List<PersonalLike>();
        temp.Add(traits);
        temp.Add(films);
        temp.Add(colours);
        temp.Add(songs);
        for(int i = 0; i < extras.Count; i++)
        {
            temp.Add(extras[i]);
        }
        return temp;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
