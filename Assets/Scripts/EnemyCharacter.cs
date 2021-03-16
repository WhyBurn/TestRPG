using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    private EnemyData data;

    public EnemyCharacter(EnemyData d)
    {
        data = d;
        stats = new int[d.baseStats.Length];
        for(int i = 0; i < stats.Length; ++i)
        {
            stats[i] = d.baseStats[i];
        }
        defenses = new int[d.baseStats.Length];
        for(int i = 0; i < defenses.Length; ++i)
        {
            defenses[i] = d.baseDefenses[i];
        }
        skills = d.skills;
        initiative = 0;
        initiativeGoal = d.initiativeGoal;
        maxHp = d.maxHealth;
        health = MaxHealth();
        mana = 0;
        adrenaline = 0;
        statuses = new List<Status>();
        portraitModel = d.portrait;
    }
}
