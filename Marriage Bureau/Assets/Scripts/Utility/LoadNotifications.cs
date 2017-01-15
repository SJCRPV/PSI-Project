using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNotifications : MonoBehaviour {

    private NotificationList notificationList;
    private InteractWithDB dbInteractionScript;
    private Dossier dossierScript;

    private void assembleNotifications(string[][] data)
    {
        notificationList = new NotificationList();
        for(int i = 0; i < data.Length; i++)
        {
            notificationList.addNotification(new Notification(data[i][0], Convert.ToInt64(data[i][1]), data[i][2], Convert.ToBoolean(data[i][3])));
        }
    }

    private void prepareNotificationsForAssembly(string[] data)
    {
        string[][] tmp = new string[data.Length][];
        for (int i = 0; i < data.Length; i++)
        {
            tmp[i] = data[i].Split(';');
        }
        assembleNotifications(tmp);
    }

    private IEnumerator fetchNotifications()
    {
        dbInteractionScript.getSingleFromDB("http://psiwebservice/fetchNotifications.php", new string[2] { "receiver", dossierScript.Username });
        while(dbInteractionScript.IsRequesting)
        {
            yield return null;
        }
        prepareNotificationsForAssembly(dbInteractionScript.CleanData);
    }

	// Use this for initialization
	void Start () {
        dbInteractionScript = GameObject.Find("HolderOfValues").GetComponent<InteractWithDB>();
        dossierScript = GameObject.Find("User").GetComponent<Dossier>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
