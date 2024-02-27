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
        if (Input.GetKeyDown(KeyCode.E) && gameStarted == false)
        {
            Debug.Log("Press 'F' to encounter your first enemy.");

            gameStarted = true;
        }


        if (Input.GetKeyDown(KeyCode.F) && gameStarted == true && inCombat == false && playerOne.currentPlayerHealth > 0)
        {
            Debug.Log("Enemy has appeared.");
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
            Debug.Log("Press 'R' to attack enemy.");
        }

        if (Input.GetKeyDown(KeyCode.R) && inCombat == true)
        {
            if (playerTurn == true && enemyTurn == false)
            {
                #region PlayerTurn


                playerOne.damageDealt = playerOne.playerAttack - enemyOne.enemyDefence;
                enemyOne.enemyHealth -= playerOne.damageDealt;

                Debug.Log("Player attacked enemy and dealt " + playerOne.damageDealt + " damage.");
                Debug.Log("Enemy now has " + enemyOne.enemyHealth + " health remaining.");

                playerTurn = false;
                enemyTurn = true;

                if (enemyOne.enemyHealth > 0)
                {
                    Debug.Log("Press 'R' for the Enemies turn.");
                }
                if (enemyOne.enemyHealth <= 0)
                {
                    Debug.Log("You defeated the enemy!");

                    playerTurn = false;
                    enemyTurn = false;
                    inCombat = false;

                    playerOne.currentPlayerHealth = playerOne.maxPlayerHealth;
                    playerOne.currentExp += enemyOne.ExpGained;
                    Debug.Log("You gained " + enemyOne.ExpGained + " experience, you now have " + playerOne.currentExp + " experience, you need " + playerOne.levelUpRequirement + " total experience to level up.");
                   
                    if (playerOne.currentExp >= playerOne.levelUpRequirement)
                    {
                        Debug.Log("Press 'Space' to level up, or press 'F' to start a new battle.");
                    }
                    else
                    {
                        Debug.Log("Press 'F' to start a new battle.");
                    }

                }

                #endregion
            }
            else if (enemyTurn == true && playerTurn == false)
            {
                enemyOne.damageDealt = enemyOne.enemyAttack - playerOne.playerDefence;
                playerOne.currentPlayerHealth -= enemyOne.damageDealt;

                Debug.Log("Enemy attacked player and dealt " + enemyOne.damageDealt + " damage.");
                Debug.Log("Player now has " + playerOne.currentPlayerHealth + " health remaining.");

                enemyTurn = false;
                playerTurn = true;

                if (playerOne.currentPlayerHealth > 0)
                {
                    Debug.Log("Press 'R' for the Player's turn.");
                }
                if (playerOne.currentPlayerHealth <= 0)
                {
                    

                    playerTurn = false;
                    enemyTurn = false;
                    inCombat = false;

                    playerOne.currentPlayerHealth = playerOne.maxPlayerHealth;

                    Debug.Log("You Lost! Press 'F' to start a new battle.");
                }
            }

        }


        // PLAYER LEVEL UP STATEMENT
        if (Input.GetKeyDown(KeyCode.Space) && !inCombat && playerOne.currentExp >= playerOne.levelUpRequirement)
        {
            playerOne.PlayerLeveledUp();
        }


    }

    public void Win()
    {
        gameWon = true;
        Debug.Log("YOU WON!");
    }

    
}
