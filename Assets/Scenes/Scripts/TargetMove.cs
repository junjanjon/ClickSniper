using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Rigidbody _rigidbody;
    private float time = 0.1f;
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
        }
        _rigidbody.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed);
        
        if (60 < transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
