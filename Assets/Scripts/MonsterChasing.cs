﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasing : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target, Vector3.up);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
