using UnityEngine;
using System.Collections;

public class Notification {

    private string sender;
    private long time;
    private string text;
    private bool isSeen;
    private bool isMatchProposal;

    public long Time
    {
        get
        {
            return time;
        }
    }

    public string Text
    {
        get
        {
            return text;
        }
    }

    public bool IsSeen
    {
        get
        {
            return isSeen;
        }
    }

    public bool IsMatchProposal
    {
        get
        {
            return isMatchProposal;
        }
    }

    public string Sender
    {
        get
        {
            return sender;
        }
    }

    public Notification(string newSender, long newTime, string newText, bool newIsMatchProposal)
    {
        sender = newSender;
        time = newTime;
        text = newText;
        isSeen = false;
        isMatchProposal = newIsMatchProposal;
    }
}
