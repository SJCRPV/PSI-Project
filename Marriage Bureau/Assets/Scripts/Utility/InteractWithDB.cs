using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Compile with: /unsafe

public class InteractWithDB : MonoBehaviour
{
    private WWW www;
    private WWWForm form;
    private string[] cleanData;
    private bool isRequesting;

    public bool IsRequesting
    {
        get
        {
            return isRequesting;
        }
    }

    public string[] CleanData
    {
        get
        {
            return cleanData;
        }
    }

    private void prepareReturnData()
    {
        cleanData = www.text.Split(',');
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

        if (hasDataToReturn)
        {
            prepareReturnData();
        }
    }

    public void getFromDB(string destinationURL)
    {
        www = new WWW(destinationURL);
        StartCoroutine(WaitForRequest(www, true));
    }

    public void getSingleFromDB(string destinationURL, string[] nameAndValue)
    {
        form = new WWWForm();
        for(int i = 0; i < nameAndValue.Length; i++)
        {
            form.AddField(nameAndValue[0], nameAndValue[1]);
        }
        StartCoroutine(WaitForRequest(www, true));
    }

    public void getSelectWhereFromDB(string destinationURL, string[] varNames, string[][] conditionsArray)
    {
        form = new WWWForm();
        for(int i = 0; i < varNames.Length; i++)
        {
            form.AddField(varNames[i], varNames[i]);
        }
        for (int i = 0; i < conditionsArray.Length; i++)
        {
            form.AddField(conditionsArray[0][i], conditionsArray[1][i]);
        }

        www = new WWW(destinationURL, form);
        StartCoroutine(WaitForRequest(www, true));
    }

    public void sendToDB(string destinationURL, string[] varNames, string[] varValues)
    {
        form = new WWWForm();
        for (int i = 0; i < varNames.Length; i++)
        {
            form.AddField(varNames[i], varValues[i]);
        }
        www = new WWW(destinationURL, form);
        StartCoroutine(WaitForRequest(www, false));
    }
}
