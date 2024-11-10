using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform _posA, _posB;
    public int _speed;
    private Vector2 _targetPos;


    void Start()
    {
        _targetPos = _posB.position;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, _posA.position) < 0.1f)
        {
            _targetPos = _posB.position;
        }
        else if (Vector2.Distance(transform.position, _posB.position) < 0.1f)
        {
            _targetPos = _posA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(_posA.position, _posB.position);
    }
}