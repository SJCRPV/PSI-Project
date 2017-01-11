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

    public string getFieldElementAtIndex(int index)
    {
        return fieldElements[index];
    }

    public string toString()
    {
        string t = fieldName + " - ";
        for(int i = 0; i < fieldElements.Length; i++)
        {
            t += fieldElements[i] + ", ";
        }
        return t;
    }

    public PersonalLike(string newFieldName, string[] newFieldElements)
    {
        fieldName = newFieldName;
        fieldElements = newFieldElements;
    }
}
