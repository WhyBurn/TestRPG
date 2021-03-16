using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatusData", order = 6)]
public class StatusData : ScriptableObject
{
    public int id;
    public string statusName;
    public Data.RemoveType removed;
    public int removalVariable;
    public float[] statModifier;
    public float[] defenseModifier;
    public StatusData[] onRemoved;
    public int minDamage;
    public int maxDamage;
    public int damagePercentage;
    public int sturdyChance;
    public GameObject model;
}
