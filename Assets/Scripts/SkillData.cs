using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillData", order = 6)]
public class SkillData : ScriptableObject
{
    public string skillName;
    public string description;
    public bool passive;
    public int hpCost;
    public int mpCost;
    public int apCost;
    public Data.TargetType target;
    public int apGain;
    public int attackStrength;
    public int level;
    public StatusData[] statuses;
    public int[] statusChances;
    public int minHealing;
    public int maxHealing;
    public int healingPercentage;
    public int weaponAttackPercentage;
    public int adrenalineGiven;
    public int minMpGain;
    public int maxMpGain;
    public int mpGainPercentage;
}
