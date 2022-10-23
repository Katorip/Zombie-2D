// Manages picking up objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour
{
    public Text textArea;
    public string pickUpText = "";
    public StaticScript statics;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            statics.AddList(gameObject.name);
            textArea.text = pickUpText;
            Destroy(gameObject);
        }
    }
}
