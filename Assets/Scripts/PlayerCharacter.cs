using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    private int exp;
    private int expIntercept;
    private int expSlope;
    private CharacterData data;
    private Job job;
    private List<Item> equiped;

    public PlayerCharacter(CharacterData d)
    {
        data = d;
        exp = 0;
        expIntercept = d.expIntercept;
        expSlope = d.expSlope;
        stats = new int[d.baseStats.Length];
        for(int i = 0; i < stats.Length; ++i)
        {
            stats[i] = d.baseStats[i];
        }
        defenses = new int[d.baseDefenses.Length];
        for(int i = 0; i < defenses.Length; ++i)
        {
            defenses[i] = d.baseDefenses.Length;
        }
        job = new Job(d.defaultJob);
        SetSkills();
        maxHp = d.maxHealth;
        maxMp = d.maxMana;
        health = MaxHealth();
        mana = MaxMana();
        adrenaline = 0;
        statuses = new List<Status>();
        equiped = new List<Item>();
        initiative = 0;
        initiativeGoal = d.initiativeGoal;
        portraitModel = d.portrait;
    }
    public PlayerCharacter(CharacterData d, int e, int[] s, int[] de, Job j, int h, int m, List<Item> eq)
    {
        data = d;
        exp = e;
        expIntercept = d.expIntercept;
        expSlope = d.expSlope;
        stats = new int[s.Length];
        for(int i = 0; i < s.Length; ++i)
        {
            stats[i] = s[i];
        }
        for(int i = 0; i < de.Length; ++i)
        {
            defenses[i] = de[i];
        }
        job = j;
        SetSkills();
        maxHp = d.maxHealth;
        maxMp = d.maxMana;
        health = MaxHealth();
        mana = MaxMana();
        adrenaline = 0;
        statuses = new List<Status>();
        equiped = new List<Item>();
        for(int i = 0; i < eq.Count; ++i)
        {
            equiped.Add(eq[i]);
        }
        initiative = 0;
        initiativeGoal = d.initiativeGoal;
        portraitModel = d.portrait;
    }

    public int RequiredExperience
    {
        get
        {
            return ((Level * expSlope) + expSlope);
        }
    }
    public int Level
    {
        get
        {
            int level = 0;
            while((level * expSlope) + expIntercept < exp)
            {
                ++level;
            }
            return (level);
        }
    }

    public override int MaxHealth()
    {
        int boost = 0;
        for (int i = 0; i < equiped.Count; ++i)
        {
            boost += equiped[i].Info.hpUp;
        }
        return (base.MaxHealth() + (Level * 12) + (53 * GetStat(Data.Stat.vitality)) + boost);
    }
    public override int MaxMana()
    {
        int boost = 0;
        for (int i = 0; i < equiped.Count; ++i)
        {
            boost += equiped[i].Info.mpUp;
        }
        return (base.MaxMana() + (Level * 17) + (21 * GetStat(Data.Stat.intelligence)) + boost);
    }
    public override int GetStat(Data.Stat stat)
    {
        int s = 0;
        float multiplier = 1;
        for(int i = 0; i < equiped.Count; ++i)
        {
            s += equiped[i].Info.statIncrease[(int)stat];
            multiplier *= equiped[i].Info.statMultiplier[(int)stat];
        }
        return (Mathf.CeilToInt(multiplier * (base.GetStat(stat) + s)));
    }
    public override int GetStat(int stat)
    {
        int s = 0;
        float multiplier = 1;
        for (int i = 0; i < equiped.Count; ++i)
        {
            s += equiped[i].Info.statIncrease[stat];
            multiplier *= equiped[i].Info.statMultiplier[stat];
        }
        return (Mathf.CeilToInt(multiplier * (base.GetStat(stat) + s)));
    }
    public override int GetDefense(Data.Defense defense)
    {
        int s = 0;
        float multiplier = 1;
        for (int i = 0; i < equiped.Count; ++i)
        {
            s += equiped[i].Info.defenseIncrease[(int)defense];
            multiplier *= equiped[i].Info.defenseMultiplier[(int)defense];
        }
        return (Mathf.CeilToInt(multiplier * (base.GetDefense(defense) + s)));
    }
    public override int GetDefense(int defense)
    {
        int s = 0;
        float multiplier = 1;
        for (int i = 0; i < equiped.Count; ++i)
        {
            s += equiped[i].Info.defenseIncrease[defense];
            multiplier *= equiped[i].Info.defenseMultiplier[defense];
        }
        return (Mathf.CeilToInt(multiplier * (base.GetDefense(defense) + s)));
    }
    public override int GetInitiativeGoal()
    {
        int change = 0;
        for(int i = 0; i < equiped.Count; ++i)
        {
            change += equiped[i].Info.initiativeChange;
        }
        return(base.GetInitiativeGoal() - (7 * GetStat(Data.Stat.agility)) + change);
    }

    public void SetSkills()
    {
        List<SkillData> s = new List<SkillData>();
        for(int i = 0; i < job.Info.skills.Length; ++i)
        {
            if(job.Info.skills[i].level <= job.Level)
            {
                s.Add(job.Info.skills[i]);
            }
        }
        for(int i = 0; i < data.defaultSkills.Length; ++i)
        {
            if(data.defaultSkills[i].level <= Level)
            {
                s.Add(data.defaultSkills[i]);
            }
        }
        skills = new SkillData[s.Count];
        for (int i = 0; i < s.Count; ++i)
        {
            skills[i] = s[i];
        }
    }
}
