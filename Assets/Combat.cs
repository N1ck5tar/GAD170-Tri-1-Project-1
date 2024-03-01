using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    // This is to interact with the other scripts to change and get values.
    public PlayerOne playerOne;
    public EnemyOne enemyOne;

    // The turn based system for fighting an enemy
    public bool inCombat = false;
    public bool gameStarted = false;
    public bool gameWon = false;

    public bool playerTurn = false;
    public bool enemyTurn = false;

    public int turns;
    public int enemiesDefeated;


    void Start()
    {

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameStarted == false) // Starts the game loop
        {
            Debug.Log("Press 'F' to encounter your first enemy."); // Tells the player to press 'F' to encounter their first enemy

            gameStarted = true;
        }

        // enemy appears based on the player level puts the player into combat and is the players turn at the start
        if (Input.GetKeyDown(KeyCode.F) && gameStarted == true && inCombat == false && playerOne.currentPlayerHealth > 0)
        {
            Debug.Log("Enemy has appeared."); // Tells the player an enemy has spawned
            if (playerOne.playerLevel <= 2)
            {
                enemyOne.FirstSetLevel();
            }
            else
            {
                enemyOne.SecondSetLevel();
            }

            inCombat = true;
            playerTurn = true;
            enemyTurn = false;
            Debug.Log("Press 'R' to attack enemy."); // Debugs how to attack the enemy
        }

        if (Input.GetKeyDown(KeyCode.R) && inCombat == true) // Runs the code to advance in combat
        {
            if (playerTurn == true && enemyTurn == false) // Checks if it is the players turn
            {
                #region PlayerTurn


                playerOne.damageDealt = playerOne.playerAttack - enemyOne.enemyDefence; // Final damage that will be dealt to the enemy
                enemyOne.enemyHealth -= playerOne.damageDealt; // Final damage dealt to the enemies health

                Debug.Log("Player attacked enemy and dealt " + playerOne.damageDealt + " damage."); // Debugs the amount of damage dealt
                Debug.Log("Enemy now has " + enemyOne.enemyHealth + " health remaining."); // Shows how much health the enemy has remaining

                // Changes the turn to the enemy
                playerTurn = false;
                enemyTurn = true;

                if (enemyOne.enemyHealth > 0) // Checks if the enemy is above 0 health
                {
                    Debug.Log("Press 'R' for the Enemies turn."); // Tells the player its the enemies turn
                }
                if (enemyOne.enemyHealth <= 0) // Checks if the enemy is at 0 or less health
                {
                    Debug.Log("You defeated the enemy!"); // Tells the player the enemy has been defeated

                    // Makes the player go out of combat
                    playerTurn = false;
                    enemyTurn = false;
                    inCombat = false;

                    // Player Gains Exp
                    playerOne.currentPlayerHealth = playerOne.maxPlayerHealth;
                    playerOne.currentExp += enemyOne.ExpGained;
                    Debug.Log("You gained " + enemyOne.ExpGained + " experience, you now have " + playerOne.currentExp + " experience, you need " + playerOne.levelUpRequirement + " total experience to level up."); // Debugs information about their Exp
                   
                    if (playerOne.currentExp >= playerOne.levelUpRequirement)
                    {
                        Debug.Log("Press 'Space' to level up, or press 'F' to start a new battle."); // Tells the player they can level up again or go into combat instead
                    }
                    else
                    {
                        Debug.Log("Press 'F' to start a new battle."); // Tells the player to go into combat
                    }

                }

                #endregion
            }
            else if (enemyTurn == true && playerTurn == false) // Checks if its the enemies turn
            {
                enemyOne.damageDealt = enemyOne.enemyAttack - playerOne.playerDefence; // Final damage that will be dealt to the player
                playerOne.currentPlayerHealth -= enemyOne.damageDealt; // Final damage dealt to the players health

                Debug.Log("Enemy attacked player and dealt " + enemyOne.damageDealt + " damage."); // Debugs the amount of damage dealt
                Debug.Log("Player now has " + playerOne.currentPlayerHealth + " health remaining."); // Shows how much health the player has remaining
                
                // Changes the turn to the player                                                                                     
                enemyTurn = false;
                playerTurn = true;

                if (playerOne.currentPlayerHealth > 0) // Checks if the player is above 0 health
                {
                    Debug.Log("Press 'R' for the Player's turn."); // Tells the player its their turn
                }
                if (playerOne.currentPlayerHealth <= 0) // Checks if the player is at 0 or less health
                {
                    

                    playerTurn = false;
                    enemyTurn = false;
                    inCombat = false;

                    playerOne.currentPlayerHealth = playerOne.maxPlayerHealth;

                    Debug.Log("You Lost! Press 'F' to start a new battle."); // Tells the player they have been defeated
                }
            }

        }


        // This allows the player to level up if they have the required Exp to do so
        if (Input.GetKeyDown(KeyCode.Space) && !inCombat && playerOne.currentExp >= playerOne.levelUpRequirement)
        {
            playerOne.PlayerLeveledUp();
        }


    }

    public void Win() // The player wins!
    {
        gameWon = true;
        Debug.Log("YOU WON!"); // Tells the player they have won
    }

    
}
