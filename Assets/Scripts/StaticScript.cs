// Game statistics

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScript : MonoBehaviour
{
    public static int scores = 0;
    public static int healthItems = 0;
    public static int levels = 1;
    public static string levelName = "";
    public static float health = 12f;
    public static bool afterBattle = false;
    public static Vector3 playerPos;
    public static List<string> objects = new List<string>();

    public void AddScore(int score)
    {
        scores = scores + score;
    }

    public int GetScores()
    {
        return scores;
    }

    public void AddLevels()
    {
        levels = levels + 1;
    }

    public int GetLevels()
    {
        return levels;
    }

    public void UpdateLevelName(string name)
    {
        levelName = name;
    }

    public string GetLevelName()
    {
        return levelName;
    }

    public void UpdateHealth(float amount)
    {
        health = amount;
    }

    public float GetHealth()
    {
        return health;
    }

    public void AddHealthItems()
    {
        healthItems = healthItems + 1;
    }

    public void RemoveHealthItems()
    {
        healthItems = healthItems - 1;
    }

    public int GetHealthItems()
    {
        return healthItems;
    }

    public void SetAfterBattle(bool battle)
    {
        afterBattle = battle;
    }

    public bool GetAfterBattle()
    {
        return afterBattle;
    }

    public void SetPosition(Vector3 pos)
    {
        playerPos = pos;
    }

    public Vector3 GetPosition()
    {
        return playerPos;
    }

    public void AddList(string name)
    {
        objects.Add(name);
    }

    public void DestroyObjects()
    {
        foreach (string obj in objects)
        {
            GameObject item = GameObject.Find(obj);

            if (item)
            {
                Destroy(item);
            }          
        }
    }

    public void ResetValues()
    {
        scores = 0;
        healthItems = 0;
        levels = 1;
        levelName = "";
        health = 12f;
        afterBattle = false;
        objects.Clear();
    }
}
