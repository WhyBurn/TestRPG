using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/JobData", order = 4)]
public class JobData : ScriptableObject
{
    public string jobName;
    public int[] statIncreaseChances;
    public int[] defenseIncreaseChances;
    public SkillData[] skills;
    public int numStatIncreased;
    public int numDefenseIncreased;
    public int expIntercept;
    public int expSlope;
}
