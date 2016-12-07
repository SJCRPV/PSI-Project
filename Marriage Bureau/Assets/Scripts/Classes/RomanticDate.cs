using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RomanticDate {

    private List<RomanticDateStep> romanticDate;
    private string dateName;
    
    public string getDateName()
    {
        return dateName;
    }

    public void setDateName(string newName)
    {
        dateName = newName;
    }

    public string[] getRomanticDateSteps()
    {
        string[] temp = new string[romanticDate.Count];
        for(int i = 0; i < temp.Length; i++)
        {
            temp[i] = romanticDate[i].ToString();
        }
        return temp;
    }

    public void addNewStep(string place, long time)
    {
        RomanticDateStep newStep = new RomanticDateStep(place, time);
        romanticDate.Add(newStep);
    }
}
