using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private int _questProgress;

    void Start()
    {
        _questProgress = PlayerPrefs.GetInt("Quest");

        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);

        if (_questProgress == 0 || _questProgress == 3)
        {
            GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(125f, 125f);
        }
        else
        {
            GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
        }

        if (_questProgress > 3)
        {
            GameObject.Find("HasLogs").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
            GameObject.Find("NoLogs").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
        }
        
        if (_questProgress > 5 || _questProgress < 3)
        {
            GameObject.Find("HasEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
            GameObject.Find("NoEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
        }
    }
}
