using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeUnit : Unit
{

    public void Start()
    {
        attack = 2;
        speed = 2f;
        health = 150;
        maxHealth = health;
        attackRange = 1;

    }

    

    
}
