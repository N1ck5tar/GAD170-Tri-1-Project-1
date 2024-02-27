using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public Combat combat;

    public int playerAttack; // The players attack
    public int currentPlayerHealth; // Current health during battle
    public int maxPlayerHealth; // the maximum health of the player
    public int playerDefence; // The players defence

    public int damageDealt; // This is for the final damage dealt to the enemy after being reduced by the enemies defence.

    public float playerAttackPerLevel; // The amount of attack given to the player after levelling up
    public float playerHealthPerLevel; // The amount of health given to the player after levelling up

    public int currentExp; // The players current exp amount
    public int levelUpRequirement = 100; // Exp requirement for the player to level up
    public int playerLevel = 1; // The players current level

    
    void Start()
    {
        // This is to set the players stats at the start of the game with a random range.
        playerAttack = Random.Range(5, 11);
        maxPlayerHealth = Random.Range(20, 31);
        playerDefence = Random.Range(2, 5);

        currentPlayerHealth = maxPlayerHealth;

        Debug.Log("The Player's stats are: " + playerAttack + " Attack, " + maxPlayerHealth + " Health, " + playerDefence + " Defence."); // Debugging the players stats

        Debug.Log("Press 'E' to start."); // Debugs how to start

    }

    public void PlayerLeveledUp() // This is when the player levels up
    {
        // This levels up the player and increases the exp level requirement
        currentExp -= levelUpRequirement;
        levelUpRequirement += 20;
        playerLevel += 1;
        Debug.Log("Player is now level: " + playerLevel + ", Level up requirement is now: " + levelUpRequirement + ", Current Exp is now: " + currentExp);

        playerAttackPerLevel = playerAttack * 0.25f; // Increases attack by 25%
        playerAttack += (int)playerAttackPerLevel; // Turning attack into an int removing any decimals 

        playerHealthPerLevel = maxPlayerHealth * 0.25f; // Increases health by 25%
        maxPlayerHealth += (int)playerHealthPerLevel; // Turning health into an int removing any decimals 
        currentPlayerHealth = maxPlayerHealth; // Setting the players health to max

        Debug.Log("Player's attack has been increased to: " + playerAttack + ", Player's health has been increased to: " + maxPlayerHealth); // Debugs the updated stats to the player

        // The aftermath of levelling up
        Debug.Log("You now have " + currentExp + " experience, and now need " + levelUpRequirement + " experience to level up again.");
        if (currentExp >= levelUpRequirement)
        {
            Debug.Log("Press 'Space' to level up, or press 'F' to start a new battle.");
        }
        else if (playerLevel < 5 || playerLevel > 5)
        {
            Debug.Log("Press 'F' to start a new battle.");
        }

        if(playerLevel == 5)
        {
            combat.Win();

        }

    }
}
