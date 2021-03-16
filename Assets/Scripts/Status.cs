using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    private StatusData data;
    private int turns;

    public StatusData Info
    {
        get { return (data); }
    }

    public Status(StatusData d)
    {
        data = d;
        turns = 0;
    }

    public bool endTurn()
    {
        if((data.removed == Data.RemoveType.duration && turns > data.removalVariable) || (data.removed == Data.RemoveType.chance && Random.Range(0, 100) < data.removalVariable))
        {
            return (true);
        }
        ++turns;
        return (false);
    }
}
