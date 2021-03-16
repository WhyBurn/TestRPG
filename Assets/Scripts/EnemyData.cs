using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int maxHealth;
    public int[] baseStats;
    public int[] baseDefenses;
    public SkillData[] skills;
    public GameObject model;
    public int initiativeGoal;
    public GameObject portrait;
}
