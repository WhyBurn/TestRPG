using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public int[] stats;
    public int[] defenses;
    public SkillData[] skills;
    public int maxHp;
    public int maxMp;
    public int health;
    public int mana;
    public int adrenaline;
    public List<Status> statuses;
    public int initiative;
    public int initiativeGoal;
    public Sprite battleModel;
    public GameObject portraitModel;

    public int NumSkills
    {
        get { return (skills.Length); }
    }

    public virtual int MaxHealth()
    {
        return (maxHp);
    }
    public virtual int MaxMana()
    {
        return (maxMp);
    }

    public virtual int GetStat(Data.Stat stat)
    {
        float multiplier = 1;
        for(int i = 0; i < statuses.Count; ++i)
        {
            multiplier *= statuses[i].Info.statModifier[(int)stat];
        }
        return (Mathf.CeilToInt(multiplier * stats[(int)stat]));
    }
    public virtual int GetStat(int stat)
    {
        float multiplier = 1;
        for (int i = 0; i < statuses.Count; ++i)
        {
            multiplier *= statuses[i].Info.statModifier[stat];
        }
        return (Mathf.CeilToInt(multiplier * stats[stat]));
    }
    public virtual int GetDefense(Data.Defense defense)
    {
        float multiplier = 1;
        for (int i = 0; i < statuses.Count; ++i)
        {
            multiplier *= statuses[i].Info.defenseModifier[(int)defense];
        }
        return (Mathf.CeilToInt(multiplier * defenses[(int)defense]));
    }
    public virtual int GetDefense(int defense)
    {
        float multiplier = 1;
        for (int i = 0; i < statuses.Count; ++i)
        {
            multiplier *= statuses[i].Info.defenseModifier[defense];
        }
        return (Mathf.CeilToInt(multiplier * defenses[defense]));
    }
    public virtual int GetInitiativeGoal()
    {
        return (initiativeGoal);
    }
    public SkillData GetSkill(int index)
    {
        return (skills[index]);
    }

    public void ClearStatus()
    {
        statuses = new List<Status>();
    }
    public int Heal(int healing)
    {
        if (healing + health > MaxHealth())
        {
            healing = MaxHealth() - health;
        }
        health += healing;
        return (healing);
    }
    public bool Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            for(int i = 0; i < statuses.Count; ++i)
            {
                if(Random.Range(0, 100) < statuses[i].Info.sturdyChance)
                {
                    health = 1;
                    break;
                }
            }
        }
        return (health <= 0);
    }
}
