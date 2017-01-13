using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RomanticDateList {

    private List<RomanticDate> dateList;
    private long dossierID;

    public void addRomanticDate(RomanticDate newRomanticDate)
    {
        dateList.Add(newRomanticDate);
    }

    public long getOriginDossierID()
    {
        return dossierID;
    }
    
    public RomanticDateList(long originDossierID)
    {
        dossierID = originDossierID;
    }
}
