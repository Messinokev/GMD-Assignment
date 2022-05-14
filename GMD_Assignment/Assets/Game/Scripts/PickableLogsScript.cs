using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableLogsScript : MonoBehaviour
{
    public bool pickedUp = false;
    private int _questProgress;

    void Start()
    {
        _questProgress = PlayerPrefs.GetInt("Quest");

        if (_questProgress == 1)
        {
            GameObject.Find("PickableLogs").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("PickableLogs").GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GameObject.Find("PickableLogs").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("PickableLogs").GetComponent<BoxCollider2D>().enabled = false;
        }

        if (PlayerPrefs.GetInt("PickedLogs") == 1)
        {
            pickedUp = true;
            GameObject.Find("NoLogs").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
        }
        else
        {
            pickedUp = false;
        }

        if (pickedUp)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameObject.Find("NoLogs").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
            PlayerPrefs.SetInt("PickedLogs", 1);
            pickedUp = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void LogsLoadedBack()
    {
        if (pickedUp)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (_questProgress > 0)
        {
            PlayerPrefs.SetInt("PickedLogs", 0);
            GameObject.Find("NoLogs").GetComponent<RectTransform>().sizeDelta = new Vector2(65f, 50f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
