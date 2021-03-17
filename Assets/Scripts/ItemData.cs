using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemData", order = 4)]
public class ItemData : ScriptableObject
{
    public int itemId;
    public string itemName;
    public string description;
    public Data.ItemType itemType;
    public int hpUp;
    public int mpUp;
    public int[] statIncrease;
    public float[] statMultiplier;
    public int[] defenseIncrease;
    public float[] defenseMultiplier;
    public int hpGain;
    public int mpGain;
    public int apGain;
    public int hpPercentage;
    public int mpPercentage;
    public int attackStrength;
    public int initiativeChange;
    public StatusData status;
    public StatusData[] statusesRemoved;
}
