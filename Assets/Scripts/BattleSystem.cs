// Deals with the battle system against zombies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Battle states
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    // Health scripts
    public PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;

    // UI elements
    public GameObject continueButton;
    public GameObject newGameButton;
    public GameObject quitButton;
    public GameObject gameOverText;
    public Text healthText;
    public Text dialogueText;

    // Game handling scripts
    public StaticScript statics;
    public SceneHandler scenes;

    // Battle state
    public BattleState state;

    void Start()
    {
        // Initialize game state and UI elements and start the battle
        state = BattleState.START;
        healthText.text = "Health items: " + statics.GetHealthItems();
        continueButton.SetActive(false);
        newGameButton.SetActive(false);
        quitButton.SetActive(false);
        gameOverText.SetActive(false);
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        dialogueText.text = "Zombie attack!";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    // Damage an enemy
    IEnumerator PlayerAttack()
    {           
        // Attack animation
        playerHealth.StartAttack();

        yield return new WaitForSeconds(1f);

        // Stop attack animation
        playerHealth.StopAttack();

        // Deal damage to an enemy based on strength assigned to the player
        bool isDead = enemyHealth.TakeDamage(playerHealth.damage);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(1.5f);

        // Check if the enemy is dead
        if (isDead)
        {
            // End the battle
            state = BattleState.WON;
            EndBattle();
            enemyHealth.Dead();
            statics.AddScore(100);
            continueButton.SetActive(true);
        }
        else
        {
            // Enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        // Change state based on what happened
    }

    // Damage player
    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Zombie attacks!";

        // Attack animation
        enemyHealth.StartAttack(); 

        yield return new WaitForSeconds(1f);

        // Stop attack animation
        enemyHealth.StopAttack();

        // Deal damage to player based on strength assigned to the enemy
        bool isDead = playerHealth.TakeDamage(enemyHealth.damage);
        

        yield return new WaitForSeconds(1f);

        // Check if player is dead
        if (isDead)
        {
            // End the battle
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            // Enemy turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    // Happens after battle is ended
    void EndBattle()
    {
        // If player wins
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        // If player dies
        else if (state == BattleState.LOST)
        {
            playerHealth.Dead();
            newGameButton.SetActive(true);
            quitButton.SetActive(true);
            gameOverText.SetActive(true);
            dialogueText.text = "You were defeated!";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action";
    }

    // Player chooses to use healing item
    IEnumerator PlayerHeal()
    {
        // Add health to player and remove 1 healing item from inventory
        playerHealth.Heal(6);
        statics.RemoveHealthItems();

        // Update UI
        dialogueText.text = "You feel renewed strength!";
        healthText.text = "Health items: " + statics.GetHealthItems();

        yield return new WaitForSeconds(2f);

        // Change turn
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    // UI attack button
    public void OnAttackButton()
    {
        // Check is it players turn
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    // UI heal button
    public void OnHealButton()
    {
        // Check is it players turn
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        // Check is there any healing items left
        if (statics.GetHealthItems() > 0)
        {
            StartCoroutine(PlayerHeal());
        }
        else
        {
            dialogueText.text = "You don't have any healing items.";
            return;
        }      
    }

    // UI continue button
    public void ContinueButton()
    {
        statics.SetAfterBattle(true);
        scenes.LoadNewScene(statics.GetLevelName());
    }
}
