using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Personality : Person {

    //TODO: Get a public definition of an IEnumerator. Likely just a public List. Or at least serialized.
    private PersonalLike traits;
    private PersonalLike films;
    private PersonalLike colours;
    private PersonalLike songs;
    private List<PersonalLike> extras;

    public string getPLikeTitleAtIndex(int index)
    {
        return extras[index].getFieldName();
    }

    public PersonalLike getPLikeAtIndex(int index)
    {
        return extras[index];
    }

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

    
    private List<PersonalLike> getDefaultPLikes()
    {
        List<PersonalLike> temp = new List<PersonalLike>();
        temp.Add(traits);
        temp.Add(films);
        temp.Add(colours);
        temp.Add(songs);

        return temp;
    }
}
