using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPLanternHandler : MonoBehaviour
{

    private Transform cp1LanternOff;
    private Transform cp2LanternOff;
    private Transform cp3LanternOff;
    private Transform cp4LanternOff;

    private Vector3 lanternOff;
    private Vector3 lanternOn;

    // Start is called before the first frame update
    void Start()
    {
        lanternOff = new Vector3(0, 0, 0);
        lanternOn = new Vector3(1, 1, 1);

        cp1LanternOff = GameObject.Find("cp1Lantern_off").GetComponent<Transform>();
        cp2LanternOff = GameObject.Find("cp2Lantern_off").GetComponent<Transform>();
        cp3LanternOff = GameObject.Find("cp3Lantern_off").GetComponent<Transform>();
        cp4LanternOff = GameObject.Find("cp4Lantern_off").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Checkpoint1" && collision.tag == "Player")
        {
            cp1LanternOff.localScale = lanternOff;
            cp2LanternOff.localScale = lanternOn;
            cp3LanternOff.localScale = lanternOn;
            cp4LanternOff.localScale = lanternOn;
        }
        if (tag == "Checkpoint2" && collision.tag == "Player")
        {
            cp1LanternOff.localScale = lanternOn;
            cp2LanternOff.localScale = lanternOff;
            cp3LanternOff.localScale = lanternOn;
            cp4LanternOff.localScale = lanternOn;
        }
        if (tag == "Checkpoint3" && collision.tag == "Player")
        {
            cp1LanternOff.localScale = lanternOn;
            cp2LanternOff.localScale = lanternOn;
            cp3LanternOff.localScale = lanternOff;
            cp4LanternOff.localScale = lanternOn;
        }
        if (tag == "Checkpoint4" && collision.tag == "Player")
        {
            cp1LanternOff.localScale = lanternOn;
            cp2LanternOff.localScale = lanternOn;
            cp3LanternOff.localScale = lanternOn;
            cp4LanternOff.localScale = lanternOff;
        }
    }
}
