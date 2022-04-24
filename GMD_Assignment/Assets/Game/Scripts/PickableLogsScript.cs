using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableLogsScript : MonoBehaviour
{
    public bool pickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("PickedLogs") == 1)
        {
            pickedUp = true;
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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Pickedup");
            PlayerPrefs.SetInt("PickedLogs", 1);
            pickedUp = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void LogsLoadedBack()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
