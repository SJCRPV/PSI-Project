using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDB : MonoBehaviour{

    private WWW www;
    private WWWForm form;
    private string data;
    private string[] cleanData;
    private bool isRequesting;

    public string[] getCleanData()
    {
        return cleanData;
    }

    public bool isWWWRequesting()
    {
        return isRequesting;
    }

    private void prepareReturnData()
    {
        data = www.text;
        Debug.Log(data);
        cleanData = data.Split(',');
        Debug.Log(cleanData);
        isRequesting = false;
    }

    private IEnumerator WaitForRequest(WWW www, bool hasDataToReturn)
    {
        isRequesting = true;
        yield return www;

        if (www.error == null)
        {
            Debug.Log("WWW Ok! " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

        if(hasDataToReturn)
        {
            prepareReturnData();
        }
    }

    public void sendToDB(string destinationURL, string[] varNames, string[] varValues, string dbTable)
    {
        form = new WWWForm();
        for(int i = 0; i < varNames.Length; i++)
        {
            form.AddField(varNames[i], varValues[i]);
        }
        form.AddField(dbTable, dbTable);
        www = new WWW(destinationURL, form);
        StartCoroutine(WaitForRequest(www, false));
    }

    public void getFromDB(string destinationURL)
    {
        www = new WWW(destinationURL);
        StartCoroutine(WaitForRequest(www, true));
    }

    public void getSelectFromDB(string destinationURL, string[] varsToSelect, string table)
    {
        form = new WWWForm();
        for(int i = 0; i < varsToSelect.Length; i++)
        {
            form.AddField(varsToSelect[i], varsToSelect[i]);
        }

        form.AddField(table, table);

        www = new WWW(destinationURL, form);
        StartCoroutine(WaitForRequest(www, true));
    }

    public void getSelectFromDB(string destinationURL, string[] varsToSelect, string[][] conditionValues, string table)
    {
        form = new WWWForm();
        for(int i = 0; i < varsToSelect.Length; i++)
        {
            form.AddField(varsToSelect[i], varsToSelect[i]);
        }

        for(int i = 0; i < conditionValues.Length; i++)
        {
            form.AddField(conditionValues[0][i], conditionValues[1][i]);
        }

        form.AddField("table", table);

        www = new WWW(destinationURL, form);
        StartCoroutine(WaitForRequest(www, true));
    }

    private InteractWithDB()
    {
        
    }
}
