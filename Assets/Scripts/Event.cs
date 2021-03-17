using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EventData", order = 3)]
public class Event : ScriptableObject
{
    public Data.EventType eventType;
    public string description;
    public string requiredVariable;
    public int minValue;
    public int maxValue;

    public Event() { }
    public Event(Data.EventType e, string d, string v, int min, int max)
    {
        eventType = e;
        description = d;
        requiredVariable = v;
        minValue = min;
        maxValue = max;
    }
}
