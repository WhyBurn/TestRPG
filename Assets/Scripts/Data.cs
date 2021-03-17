using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public enum Stat { vitality = 0, strength = 1, dextarity = 2, intelligence = 3, wisdom = 4, agility = 5 };//Vitality increases maximum health. Strength increases str based skills, and decreases physical damage. Dextarity increases dex based skills, and increases ap gain. Intelligence increases int based skills, and mp pool. Wisdom increases wis based skills, and decreases elemental damage. Agility increases crit rate, and dodge chance, while decreasing initiative requirement.
    public enum Defense { physical = 0, fire = 1, electric = 2, water = 3, ice = 4, light = 5, dark = 6 };
    public enum RemoveType { duration = 0, indefinate = 1, chance = 2 };
    public enum TargetType { self = 0, ally = 1, enemy = 2, allAllies = 3, allEnemies = 4 };
    public enum ItemType { weapon = 0, helmet = 1, armor = 2, accessory = 3, consumable = 4, keyItem = 5};
    public enum EventType { dialog = 0, changeValue = 1, startBattle = 2};

    public static Vector2 defaultResolution = new Vector2(800, 600);
}
