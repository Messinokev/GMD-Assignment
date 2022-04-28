using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableEggScript : MonoBehaviour
{
    public bool pickedUp = false;
    private int _questProgress;

    
    void Start()
    {
        _questProgress = PlayerPrefs.GetInt("Quest");

        if (_questProgress == 4)
        {
            GameObject.Find("PickableEgg").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("PickableEgg").GetComponent<CapsuleCollider2D>().enabled = true;
        }
        else
        {
            GameObject.Find("PickableEgg").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("PickableEgg").GetComponent<CapsuleCollider2D>().enabled = false;
        }

        if (PlayerPrefs.GetInt("PickedEgg") == 1)
        {
            pickedUp = true;
            GameObject.Find("NoEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
        }
        else
        {
            pickedUp = false;
        }

        if (pickedUp)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameObject.Find("NoEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
            GameObject.Find("HasEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(55f, 65f);
            PlayerPrefs.SetInt("PickedEgg", 1);
            pickedUp = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    public void EggLoadedBack()
    {
        if (pickedUp)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else if (_questProgress > 3)
        {
            PlayerPrefs.SetInt("PickedEgg", 0);
            GameObject.Find("NoEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(55f, 65f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }
}
