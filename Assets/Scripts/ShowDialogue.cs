using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public StaticScript statics;
    public GameObject dialogueTrigger;

    void Start()
    {
        if (statics.GetLevels() > 1)
        {
            dialogueTrigger.SetActive(true);
        }
    }
}
