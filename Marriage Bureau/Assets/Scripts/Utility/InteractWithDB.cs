using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDB : MonoBehaviour{

    private WWW www;
    private WWWForm form;

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            Debug.Log("WWW Ok! " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
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
        StartCoroutine(WaitForRequest(www));
    }

    public string[] getFromDB(string destinationURL)
    {
        www = new WWW(destinationURL);
        StartCoroutine(WaitForRequest(www));

        string data = www.text;
        Debug.Log(data);
        string[] temp = data.Split(',');

        return temp;
    }

    public string[] getSelectFromDB(string destinationURL, string[] varsToSelect, string table)
    {
        form = new WWWForm();
        for(int i = 0; i < varsToSelect.Length; i++)
        {
            form.AddField(i.ToString(), varsToSelect[i]);
        }

        form.AddField((varsToSelect.Length + 1).ToString(), table);

        www = new WWW(destinationURL, form);
        StartCoroutine(WaitForRequest(www));

        string data = www.text;
        Debug.Log(data);
        string[] temp = data.Split(',');

        return temp;
    }

    private InteractWithDB()
    {
        
    }
}
