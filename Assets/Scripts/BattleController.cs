using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    private PlayerCharacter[] playerCharacters;
    private EnemyCharacter[] enemyCharacters;
    private int expReward;
    private int goldReward;
    private RPGAnimation currentAnimation;

    public GameObject turnOrderParent;
    public GameObject userInterface;

    // Update is called once per frame
    void Update()
    {
        float heightRatio = Data.defaultResolution.x * Screen.height / Data.defaultResolution.y / Screen.width;
        turnOrderParent.transform.localPosition = new Vector3(0, (heightRatio * (Screen.height / 2)) - 1, 0);
        userInterface.transform.localPosition = new Vector3(0, (heightRatio * (Screen.height / -2)) + 1, 0);
        if(currentAnimation != null)
        {
            if(currentAnimation.Animate(Time.deltaTime))
            {
                currentAnimation = currentAnimation.GetNextAnimation();
            }
        }
        else
        {

        }
    }

    public void SetUpBattle(List<PlayerCharacter> party, EnemyGroup enemies)
    {
        playerCharacters = new PlayerCharacter[party.Count];
        for(int i = 0; i < playerCharacters.Length; ++i)
        {
            playerCharacters[i] = party[i];
        }
        enemyCharacters = new EnemyCharacter[enemies.enemies.Length];
        for(int i = 0; i < enemyCharacters.Length; ++i)
        {
            enemyCharacters[i] = enemies.enemies[i];
        }
        goldReward = enemies.gold;
        expReward = enemies.exp;
        currentAnimation = null;
    }
    public void ClearTurnOrder()
    {
        for(int i = 0; i < turnOrderParent.transform.childCount; ++i)
        {
            Destroy(turnOrderParent.transform.GetChild(i).gameObject);
        }
    }
    public void LoadCharacterOrderPortrait(Character c, int pos)
    {
        GameObject portrait = Instantiate(c.portraitModel, turnOrderParent.transform);
        portrait.transform.localPosition = new Vector3(-240 + (60 * pos), 0, 0);
    }
    public void SetupTurnOrder()
    {
        int count = 0;
        int add = 0;
        while(count < 10)
        {
            for(int i = 0; i < playerCharacters.Length; ++i)
            {
                if((playerCharacters[i].initiative + add) % playerCharacters[i].GetInitiativeGoal() == 0)
                {
                    LoadCharacterOrderPortrait(playerCharacters[i], count);
                    ++count;
                }
                if(count >= 10)
                {
                    return;
                }
            }
            for (int i = 0; i < enemyCharacters.Length; ++i)
            {
                if ((enemyCharacters[i].initiative + add) % enemyCharacters[i].GetInitiativeGoal() == 0)
                {
                    LoadCharacterOrderPortrait(enemyCharacters[i], count);
                    ++count;
                }
                if (count >= 10)
                {
                    return;
                }
            }
            ++add;
        }
    }
    public bool PlayerTurn()
    {
        for(int i = 0; i < playerCharacters.Length; ++i)
        {
            if(playerCharacters[i].initiative >= playerCharacters[i].GetInitiativeGoal())
            {
                return (true);
            }
        }
        return (false);
    }
    public bool EnemyTurn()
    {
        for(int i = 0; i < enemyCharacters.Length; ++i)
        {
            if(enemyCharacters[i].initiative >= enemyCharacters[i].GetInitiativeGoal())
            {
                return (true);
            }
        }
        return (false);
    }
    public void IncrementInitiative()
    {
        for(int i = 0; i < playerCharacters.Length; ++i)
        {
            playerCharacters[i].initiative++;
        }
        for(int i = 0; i < enemyCharacters.Length; ++i)
        {
            enemyCharacters[i].initiative++;
        }
    }
    public Character GetActiveCharacter()
    {
        for(int i = 0; i < playerCharacters.Length; ++i)
        {
            if(playerCharacters[i].initiative >= playerCharacters[i].GetInitiativeGoal())
            {
                return (playerCharacters[i]);
            }
        }
        for(int i = 0; i < enemyCharacters.Length; ++i)
        {
            if(enemyCharacters[i].initiative >= enemyCharacters[i].GetInitiativeGoal())
            {
                return (enemyCharacters[i]);
            }
        }
        return (null);
    }
}
