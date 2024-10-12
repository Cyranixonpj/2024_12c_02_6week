using System.Collections;
using UnityEngine;

namespace Platfroms
{
    public class CollapsingPlatform : MonoBehaviour
    {
        [SerializeField] private float closeAgainCooldown;
        [SerializeField] private float openDelay;
        [SerializeField] private BoxCollider2D bxCol;
        private bool _isOpening = false;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_isOpening)
                return;
            if (other.transform.tag=="Player")
            {
                _isOpening = true;
                StartCoroutine(Opening());
            }
        
        }
        private IEnumerator Opening()
        {
            while (true)
            {
                _isOpening = true;
                yield return new WaitForSeconds(openDelay);
                bxCol.enabled = false;
                yield return new WaitForSeconds(closeAgainCooldown);
                bxCol.enabled = true;
            }
        }
    }
}
