using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RomanticDateList {

    private List<RomanticDate> dateList;
    private int dossierID;

    public void addRomanticDate(RomanticDate newRomanticDate)
    {
        dateList.Add(newRomanticDate);
    }

    public int getOriginDossierID()
    {
        return dossierID;
    }
    
    public RomanticDateList(int originDossierID)
    {
        dossierID = originDossierID;
    }
}
