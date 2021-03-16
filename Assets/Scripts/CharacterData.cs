using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterData", order = 0)]
public class CharacterData : ScriptableObject
{
    public int maxHealth;
    public int maxMana;
    public int expIntercept;
    public int expSlope;
    public JobData[] availableJobs;
    public int[] baseStats;
    public int[] baseDefenses;
    public SkillData[] defaultSkills;
    public JobData defaultJob;
    public GameObject model;
    public int initiativeGoal;
    public GameObject portrait;
}
