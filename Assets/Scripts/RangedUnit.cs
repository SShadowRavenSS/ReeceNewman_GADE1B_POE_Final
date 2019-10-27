using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedUnit : Unit
{

    public void Start()
    {
        attack = 1;
        speed = 2f;
        health = 100;
        maxHealth = health;
        attackRange = 2;

    }

}
