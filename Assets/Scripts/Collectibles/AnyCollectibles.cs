using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectibles
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class AnyCollectibales : MonoBehaviour
    {
        protected abstract void Collect();

        private void OnTriggerEnter2D(Collider2D otherObject)
        {
            Collect();
        }
    }
}