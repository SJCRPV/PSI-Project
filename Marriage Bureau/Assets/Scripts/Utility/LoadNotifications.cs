using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadNotifications : MonoBehaviour {

    public GameObject notificationPrefab;

    private GameObject notificationInstance;
    private NotificationList notificationList;
    private InteractWithDB dbInteractionScript;
    private Dossier dossierScript;

    public void displayNotifications()
    {
        Vector3 spawnPos = gameObject.transform.position;
        for (int i = 0; i < notificationList.getLength(); i++)
        {
            Notification tempNotification = notificationList.getNotificationAtIndex(i);
            spawnPos.y += -100 * i;
            notificationInstance = Instantiate(notificationPrefab, spawnPos, Quaternion.identity);
            notificationInstance.GetComponentInChildren<Text>().text = tempNotification.Sender + "\t" + tempNotification.Time + "\n" + tempNotification.Text;
        }
    }

    private void assembleNotifications(string[][] data)
    {
        notificationList = new NotificationList();
        for(int i = 0; i < data.Length; i++)
        {
            notificationList.addNotification(new Notification(data[i][0], Convert.ToInt64(data[i][1]), data[i][2], Convert.ToBoolean(data[i][3])));
        }
        displayNotifications();
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
        fetchNotifications();
	}
}
