using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/JobData", order = 5)]
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

    public JobData() { }
    public JobData(string jN, int[] sIC, int[] dIC, SkillData[] s, int nSI, int nDI, int eI, int eS)
    {
        jobName = jN;
        statIncreaseChances = sIC;
        defenseIncreaseChances = dIC;
        skills = s;
        numStatIncreased = nSI;
        numDefenseIncreased = nDI;
        expIntercept = eI;
        expSlope = eS;
    }
}
