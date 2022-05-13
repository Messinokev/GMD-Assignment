using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
   public Animator animator;
   private GameObject door;

   private void Start()
   {
      door = GameObject.Find("Door");
   }

   public void Pull()
   {
      animator.Play("Lever_Pull");
      Destroy(door.gameObject);
   }
}
