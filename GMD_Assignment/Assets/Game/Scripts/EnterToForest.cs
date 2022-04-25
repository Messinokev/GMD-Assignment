using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToForest : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("Quest") > 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
