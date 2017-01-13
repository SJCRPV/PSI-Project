using UnityEngine;
using System.Collections;

public class Notification {

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

    public Notification(long newTime, string newText, bool newIsMatchProposal)
    {
        time = newTime;
        text = newText;
        isSeen = false;
        isMatchProposal = newIsMatchProposal;
    }
}
