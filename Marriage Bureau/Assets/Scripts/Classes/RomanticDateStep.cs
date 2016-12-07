using UnityEngine;
using System.Collections;

public class RomanticDateStep {

    private string place;
    private long time;

    public string getPlace()
    {
        return place;
    }
    public void setPlace(string newPlace)
    {
        place = newPlace;
    }

    public long getTime()
    {
        return time;
    }
    public void setTime(long newTime)
    {
        time = newTime;
    }

    public override string ToString()
    {
        return place + "-" + time;
    }

    public RomanticDateStep(string place, long time)
    {
        setPlace(place);
        setTime(time);
    }
}
