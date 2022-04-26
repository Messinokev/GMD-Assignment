using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private int _questProgress;

    // Start is called before the first frame update
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

        if (_questProgress == 0)
        {
            GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(125f,125f);
        }
        else
        {
            GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
        }

        if (_questProgress > 2)
        {
            GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(125f, 125f);
        }
        else
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
