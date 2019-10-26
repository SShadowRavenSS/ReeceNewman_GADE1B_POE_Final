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
        health = 10;
        maxHealth = health;
        team = Random.Range(0, 2);
        attackRange = 1;

        GetComponent<MeshRenderer>().material = mat[team];
        healthBar = GetComponentsInChildren<Image>()[1];

    }

    

    
}
