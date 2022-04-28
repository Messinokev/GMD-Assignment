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


    void Start()
    {
        lanternOff = new Vector3(0, 0, 0);
        lanternOn = new Vector3(1, 1, 1);

        cp1LanternOff = GameObject.Find("cp1Lantern_off").GetComponent<Transform>();
        cp2LanternOff = GameObject.Find("cp2Lantern_off").GetComponent<Transform>();
        cp3LanternOff = GameObject.Find("cp3Lantern_off").GetComponent<Transform>();
        cp4LanternOff = GameObject.Find("cp4Lantern_off").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (tag == "Checkpoint1" || tag == "Checkpoint6")
            {
                cp1LanternOff.localScale = lanternOff;
                cp2LanternOff.localScale = lanternOn;
                cp3LanternOff.localScale = lanternOn;
                cp4LanternOff.localScale = lanternOn;
            }
            if (tag == "Checkpoint2" || tag == "Checkpoint7")
            {
                cp1LanternOff.localScale = lanternOn;
                cp2LanternOff.localScale = lanternOff;
                cp3LanternOff.localScale = lanternOn;
                cp4LanternOff.localScale = lanternOn;
            }
            if (tag == "Checkpoint3" || tag == "Checkpoint8")
            {
                cp1LanternOff.localScale = lanternOn;
                cp2LanternOff.localScale = lanternOn;
                cp3LanternOff.localScale = lanternOff;
                cp4LanternOff.localScale = lanternOn;
            }
            if (tag == "Checkpoint4" || tag == "Checkpoint9")
            {
                cp1LanternOff.localScale = lanternOn;
                cp2LanternOff.localScale = lanternOn;
                cp3LanternOff.localScale = lanternOn;
                cp4LanternOff.localScale = lanternOff;
            }
        }
    }
}
