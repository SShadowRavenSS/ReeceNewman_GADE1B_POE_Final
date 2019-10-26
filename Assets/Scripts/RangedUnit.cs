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
        health = 10;
        maxHealth = health;
        team = Random.Range(0, 2);
        attackRange = 2;
        
        GetComponent<MeshRenderer>().material = mat[team];
        
    }

}
