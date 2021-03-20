using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerObject
{
    private static GameControllerObject GCO;
    public static GameControllerObject GetGCO()
    {
        if(GCO == null)
        {
            GCO = new GameControllerObject();
        }
        return (GCO);
    }

    private Queue<Event> events;
    private CustomVariable[] variables;
    public GameControllerObject()
    {
        events = new Queue<Event>();
        variables = new CustomVariable[0];
    }

    public bool HasEvent()
    {
        return (events.Count > 0);
    }

    public Event GetNextEvent()
    {
        return (events.Dequeue());
    }

    public void AddEvent(Event newEvent)
    {
        events.Enqueue(newEvent);
    }
}
