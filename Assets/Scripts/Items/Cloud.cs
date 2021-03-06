﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public float maxVelocity = 1;
    public float minX, maxX;

    private float velocity;
    
    void Start()
    {
        //cloud moves at random velocity
        velocity = Random.Range(-maxVelocity, maxVelocity);

        var level = GetComponentInParent<Level>();
        if (level)
        {
            minX = level.levelBounds.min.x - 8;
            maxX = level.levelBounds.max.x + 8;
        }
    }
    
    void Update()
    {
        var pos = transform.position;
        pos.x += velocity * Time.deltaTime;

        //check if out of bounds - if yes, reset position
        if (pos.x < minX)
        {
            pos.x = maxX;
        }
        else if (pos.x > maxX)
        {
            pos.x = minX;
        }

        transform.position = pos;
    }
}
