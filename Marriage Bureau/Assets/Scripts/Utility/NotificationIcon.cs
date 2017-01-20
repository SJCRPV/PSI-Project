using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationIcon : MonoBehaviour {

    public GameObject notificationPrefab;
    public GameObject notificationList;

    private GameObject notificationButton;
    private GameObject notificationInstance;

    private void makeNotification()
    {
        ////notificationInstance = Instantiate(notificationPrefab, notificationList.transform.position, Quaternion.identity);
        //notificationInstance = Instantiate(notificationPrefab, notificationList.transform);
        ////notificationInstance.transform.position = notificationList.transform.position;
        //notificationInstance.transform.localScale = new Vector3(1, 1);
    }

    private void incrementNotificationNumber()
    {
        notificationButton.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(notificationButton.GetComponent<Text>().text) + 1);
    }

    public void onClick()
    {
        incrementNotificationNumber();
        makeNotification();
    }

	// Use this for initialization
	void Start () {
        notificationButton = GameObject.Find("NotificationCounter");
	}
}
