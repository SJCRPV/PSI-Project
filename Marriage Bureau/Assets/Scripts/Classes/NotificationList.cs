using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationList {

    private List<Notification> notificationList;

    public void addNotification(Notification notificationToAdd)
    {
        notificationList.Add(notificationToAdd);
    }
}
