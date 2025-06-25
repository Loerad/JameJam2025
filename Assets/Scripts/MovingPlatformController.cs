using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] Vector2[] points;
    [SerializeField, Range(0.5f, 8f)] private float speed;
    [SerializeField, Range(0f, 5f)] private float _waitAtWaypoints;
    [SerializeField] private bool _loop;
    private int currentIndex;
    private bool _movemementEnabled = true;
    private bool _reversing = false;

    private Dictionary<Transform, Transform> _objectsOnPlatform = new Dictionary<Transform, Transform>();
    private void Start()
    {
        if(points.Length < 2)
        {
            enabled = false;
            return;
        }
        transform.position = points[0];
    }
    void Update()
    {
        if (!_movemementEnabled)
        {
            return;
        }
        if (!_loop)
        {
            if (currentIndex == 0)
            {
                _reversing = false;
            }
            else if (currentIndex == points.Length - 1)
            {
                _reversing = true;
            }
            if (transform.position == (Vector3)points[currentIndex])
            {
                if (_waitAtWaypoints > 0f)
                {
                    StartCoroutine(WaitAtWaypoints(!_reversing ? 1 : -1));
                }
                else
                {
                    currentIndex += !_reversing ? 1 : -1;
                }
            }
        }
        else {
            if (transform.position == (Vector3)points[currentIndex])
            {
                if(_waitAtWaypoints > 0f)
                {
                    StartCoroutine(WaitAtWaypoints(currentIndex != points.Length - 1 ? 1 : -(points.Length-1)));
                }
                else
                {
                    currentIndex += currentIndex != points.Length - 1 ? 1 : -(points.Length - 1);
                }
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[currentIndex], Time.deltaTime * speed);
    }
    private IEnumerator WaitAtWaypoints(int intToAdd)
    {
        _movemementEnabled = false;
        yield return new WaitForSeconds(_waitAtWaypoints);
        _movemementEnabled = true;
        currentIndex += intToAdd;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_objectsOnPlatform.ContainsKey(collision.transform))
            {
                _objectsOnPlatform.Add(collision.transform, collision.transform.parent);
                collision.transform.parent = transform;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_objectsOnPlatform.ContainsKey(collision.transform))
            {
                collision.transform.parent = _objectsOnPlatform[collision.transform];
                _objectsOnPlatform.Remove(collision.transform);
            }
        }
    }
}
