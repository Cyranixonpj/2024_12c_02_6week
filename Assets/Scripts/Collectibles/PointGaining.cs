using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectibles
{
    public class Coins : AnyCollectibales
    {
        protected override void Collect()
        {
            /// todo
            Destroy(gameObject);
        }
    }
}

