using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    // These are stats for the enemies base stats that will be added along side the enemies level stats.
    public int baseEnemyAttack;
    public int baseEnemyHealth;
    public int baseEnemyDefence;

    // This is the enemies total stats combined with base and level stats.
    public int enemyAttack;
    public int enemyHealth;
    public int enemyDefence;

    // This is for the final damage dealt to the player after being reduced by the players defence.
    public int damageDealt;

    // This increases the enemies stats per level the enemy has.
    public int enemyAttackPerLevel;
    public int enemyHealthPerLevel;
    public int enemyDefencePerLevel;

    public int enemyLevel; // The value of the enemies level.
    public int ExpGained; // The experience given to the player.


    
    void Start()
    {
        // These are to set the variables above with defence, health and damage.
        baseEnemyAttack = 4;
        baseEnemyHealth = 10;
        baseEnemyDefence = 1;
        // These are the stats given to the enemy per level.
        enemyAttackPerLevel = 2;
        enemyHealthPerLevel = 4;
        enemyDefencePerLevel = 1;
}

    public void FirstSetLevel() // This is when the player level is 2 or lower
    {
        enemyLevel = Random.Range(1, 5); // Gives the enemy a random level
        ExpGained = 50 + (enemyLevel * 15); // The amount of exp given when enemy is defeated

        // The enemies stats after base and per level have been combined
        enemyAttack = baseEnemyAttack + (enemyAttackPerLevel * enemyLevel) - enemyAttackPerLevel;
        enemyHealth = baseEnemyHealth + (enemyHealthPerLevel * enemyLevel) - enemyHealthPerLevel;
        enemyDefence = baseEnemyDefence + (enemyDefencePerLevel * enemyLevel) - enemyDefencePerLevel;
        Debug.Log("They are level: " + enemyLevel + ", their attack is: " + enemyAttack + ", their health is: " + enemyHealth + ", their defence is: " + enemyDefence);
    }
    public void SecondSetLevel() // This is when the player level is 3 or higher
    {
        enemyLevel = Random.Range(3, 7); // Gives the enemy a random level
        ExpGained = 50 + (enemyLevel * 15); // The amount of exp given when enemy is defeated

        // The enemies stats after base and per level have been combined
        enemyAttack = baseEnemyAttack + (enemyAttackPerLevel * enemyLevel) - enemyAttackPerLevel;
        enemyHealth = baseEnemyHealth + (enemyHealthPerLevel * enemyLevel) - enemyHealthPerLevel;
        enemyDefence = baseEnemyDefence + (enemyDefencePerLevel * enemyLevel) - enemyDefencePerLevel;
        Debug.Log("They are level: " + enemyLevel + ", their attack is: " + enemyAttack + ", their health is: " + enemyHealth + ", their defence is: " + enemyDefence);
    }
}
