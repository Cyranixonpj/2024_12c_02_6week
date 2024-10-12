using System.Collections;
using UnityEngine;

namespace Obstacles
{
    public class FallingCannonBallSpawnpoint : MonoBehaviour
    {
        [SerializeField] private GameObject _fallingCannonballPrefab;
        [SerializeField] private float _cooldown;
        private void Start()
        {
            StartCoroutine(Falling());
        } 
        private IEnumerator Falling()
        {
            while (true)
            {
                Instantiate(_fallingCannonballPrefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(_cooldown);
            
            }
        }
    }
}
