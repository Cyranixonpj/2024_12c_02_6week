using System;
using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
   public float knockbackTime = 0.2f;
   public float hitDirectionForce = 10f;
   public float constForce = 5f;
   public float inoutForce = 7.5f;
   public bool isBeingKnockedBack { get; private set;}
   private Coroutine _knockbackCorotine;

   private Rigidbody2D _rb;

   private void Start()
   {
      _rb = GetComponent<Rigidbody2D>();
   }


   public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
   {
      isBeingKnockedBack = true;

      Vector2 _hitForce;
      Vector2 _constantForce;
      Vector2 _knockbackForce;
      Vector2 _combinedForce;
      
      
      _hitForce = hitDirection * hitDirectionForce;
      _constantForce = constantForceDirection * constForce;
      
      float _elapsedTime = 0f;
      while (_elapsedTime < knockbackTime)
      {
         _elapsedTime += Time.fixedDeltaTime;
         _knockbackForce = _hitForce + _constantForce;


         if (inputDirection != 0)
         {
            _combinedForce = _knockbackForce + new Vector2(inputDirection , 0);
         }
         else
         {
            _combinedForce = _knockbackForce;
         }

         _rb.velocity = _combinedForce;
         yield return new WaitForFixedUpdate();
      }
      isBeingKnockedBack = false;
   }

   public void CallKnockBack(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
   {
      _knockbackCorotine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
   }

}
