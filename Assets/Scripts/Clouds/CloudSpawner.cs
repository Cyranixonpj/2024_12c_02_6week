using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cloudPrefab;
    [SerializeField] private GameObject _cloudPrefab2;
    [SerializeField] private GameObject _cloudPrefab3;
    [SerializeField] private float _spawnRate;
    [SerializeField] private Transform _targetPos;

    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            GameObject selectedCloud = GetRandomCloudPrefab();
            GameObject cloud = Instantiate(selectedCloud, transform.position, Quaternion.identity);
            StartCoroutine(MoveCloud(cloud));
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private IEnumerator MoveCloud(GameObject cloud)
    {
        Animator animator = cloud.GetComponent<Animator>();

        while (cloud != null)
        {
            cloud.transform.position =
                Vector2.MoveTowards(cloud.transform.position, _targetPos.position, Time.deltaTime);


            if (Vector2.Distance(cloud.transform.position, _targetPos.position) < 2.5f)
            {
                animator.SetTrigger("Destroyed");
                Destroy(cloud, 3f);
            }

            yield return null;
        }
    }
    private GameObject GetRandomCloudPrefab()
    {
        int randomCloud = Random.Range(0, 3);
        switch (randomCloud)
        {
            case 0:
                return _cloudPrefab;
            case 1:
                return _cloudPrefab2;
            case 2:
                return _cloudPrefab3;
            default:
                return _cloudPrefab;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _targetPos.position);
    } 
}