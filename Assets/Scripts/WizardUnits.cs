﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardUnits : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        attack = 2;
        speed = 2f;
        health = 50;
        maxHealth = health;
        team = 2;
        attackRange = 4;
        GetComponent<MeshRenderer>().material = mat[team];
    }

    

}
