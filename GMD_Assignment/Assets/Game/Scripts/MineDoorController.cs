using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDoorController : MonoBehaviour
{
    public void LeverPulled()
    {
        Destroy(gameObject);
    }
}
