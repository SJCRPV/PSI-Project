using UnityEngine;
using System.Collections;

public class PersonalLike : MonoBehaviour {

    private string fieldName;
    private string[] fieldElements;

    public string getFieldName()
    {
        return fieldName;
    }
    public string[] getFieldElements()
    {
        return fieldElements;
    }

    public string toString()
    {
        string t = fieldName + " - ";
        for(int i = 0; i < fieldElements.Length; i++)
        {
            t += fieldElements[i] + ",";
        }
        return t;

    }

	// Use this for initialization
	void Start () {
	    
	}
}
