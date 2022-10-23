// Manages player interactions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    public SceneHandler scenes;
    public StaticScript statics;
    public MainMenu menu;
    public GameObject target;

    // UI elements
    public Text pointsText;
    public Text healthItemText;
    public Text infoText;
    
    private int weapon = 0;
    private int dialogue = 0;

    void Start()
    {
        infoText.text = "The bartender needs your help! Talk to the bartender.";
        statics.DestroyObjects();

        // Set players position to what it was before battle
        if (statics.GetAfterBattle())
        {
            gameObject.transform.position = statics.GetPosition();
            target.transform.position = statics.GetPosition();
            statics.SetAfterBattle(false);
        }

        UpdateTextFields();
    }

    // When player walks into colliders
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Door")
        {
            if (statics.GetLevels() == 1 && weapon > 0 && dialogue > 0)
            {
                statics.AddLevels();
                scenes.LoadNewScene("Level1");
            }

            else if (statics.GetLevels() > 1)
            {
                statics.AddLevels();
                scenes.LoadNewScene("Level2");
            }

            else if (dialogue == 0)
            {
                infoText.text = "Talk to the bartender.";
            }
           
            else
            {
                infoText.text = "You need a weapon first.";
            }
        }

        if (col.name == "Ax")
        {
            weapon++;
        }

        if (col.name == "DialogueTrigger 1")
        {
            dialogue++;
        }

        if (col.tag == "Blood")
        {
            statics.AddHealthItems();
            UpdateTextFields();
        }

        if (col.tag == "Gold")
        {
            statics.AddScore(50);
            UpdateTextFields();
        }

        if (col.tag == "Win")
        {           
            menu.ShowMenu();   
        }

        if (col.tag == "Zombie")
        {
            statics.AddList(col.gameObject.name);
            statics.SetPosition(gameObject.transform.position);
            scenes.LoadNewScene("BattleScene");
        }

        if (col.tag == "Destroy")
        {
            statics.AddList(col.gameObject.name);
        }
    }

    private void UpdateTextFields()
    {
        pointsText.text = "Points: " + statics.GetScores();
        healthItemText.text = "Health items: " + statics.GetHealthItems();
    }
}
