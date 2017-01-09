using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDBOutput : MonoBehaviour {
    private WWW www;
    private WWWForm form;
    private Text text;
    private string data;
    private string[] cleanData;
    private bool isRequesting;
    private bool hasRun;

    private void returnData()
    {
        data = www.text;
        Debug.Log(data);
        cleanData = data.Split(',');
        Debug.Log(cleanData);
        isRequesting = false;
    }

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
        returnData();
    }

    public void getFromDB(string destinationURL)
    {
        www = new WWW(destinationURL);
        StartCoroutine(WaitForRequest(www));
    }

    public void pressToRequest()
    {
        hasRun = false;
        getFromDB("http://psiwebservice/testOutput.php");
    }

    // Use this for initialization
    void Start () {
        text = GameObject.Find("TextOutput").GetComponent<Text>();
        isRequesting = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isRequesting && !hasRun)
        {
            for (int i = 0; i < cleanData.Length; i++)
            {
                text.text += cleanData[i] + "\n";
            }
            hasRun = true;
        }
	}
}
