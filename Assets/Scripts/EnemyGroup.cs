using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyGroupData", order = 2)]
public class EnemyGroup : ScriptableObject
{
    public EnemyCharacter[] enemies;
    public int exp;
    public int gold;
    public int chance;
}
