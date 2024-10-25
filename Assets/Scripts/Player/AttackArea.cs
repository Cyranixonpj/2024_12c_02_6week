using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
   
   private void OnTriggerEnter2D(Collider2D collider)
   {
      if(collider.CompareTag("Enemy"))
      {
         Destroy(collider.gameObject);
      }
   }
}
