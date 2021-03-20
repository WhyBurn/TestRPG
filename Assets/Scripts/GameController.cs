using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject TextBackdrop;
    public GameObject EventText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameControllerObject gCO = GameControllerObject.GetGCO();
        if (gCO.HasEvent())
        {
            Event currentEvent = gCO.GetNextEvent();
            if(currentEvent.eventType == Data.EventType.changeValue)
            {
                string[] stringValues = currentEvent.description.Split(';');

            }
        }
    }
}
