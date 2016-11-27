using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Personality : MonoBehaviour {

    //TODO: Get a public definition of an IEnumerator. Likely just a public List. Or at least serialized.
    private PersonalLike traits;
    private PersonalLike films;
    private PersonalLike colours;
    private PersonalLike songs;
    private List<PersonalLike> completeList;

    public string getPLikeTitleAtIndex(int index)
    {
        return completeList[index].getFieldName();
    }

    public List<PersonalLike> getPreferences()
    {
        return completeList;
    }

    private void loadDefaultsIntoList()
    {
        completeList.Add(traits);
        completeList.Add(films);
        completeList.Add(colours);
        completeList.Add(songs);
    }

	// Use this for initialization
	void Start () {
        loadDefaultsIntoList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
