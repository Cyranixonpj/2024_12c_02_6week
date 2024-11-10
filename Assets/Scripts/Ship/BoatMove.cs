using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _shipWheel;
    [SerializeField] private Transform _targetPos;
    [SerializeField] private GameObject _mast;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_shipWheel.GetComponent<ShipWheel>().hasPlayerTriggered)
        {
            _mast.GetComponent<Animator>().SetTrigger("TransToWind");
            _mast.GetComponent<Animator>().SetTrigger("WindActive");
            
            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, _speed * Time.deltaTime);
        }
        else
        {
            _mast.GetComponent<Animator>().SetTrigger("TransToNOWind");
            _mast.GetComponent<Animator>().SetTrigger("IdleReturn");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, _targetPos.position);
    }
}