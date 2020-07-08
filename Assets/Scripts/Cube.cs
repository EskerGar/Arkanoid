using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    protected int health = 1;
    
    
    protected void HealthChange(int amount)
    {
        health -= amount;
        if(health != 0) return;
        Destroy(this);
    }
}
