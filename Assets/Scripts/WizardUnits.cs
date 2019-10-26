using System.Collections;
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
        health = 10;
        maxHealth = health;
        team = 2;
        attackRange = 1;

       // GetComponent<MeshRenderer>().material = mat[team];
       // healthBar = GetComponentsInChildren<Image>()[1];
    }

    private void AoeAttack(Unit[] possibleTargets)
    {
        for (int i = 0; i < possibleTargets.Length; i++)
        {
            if(IsInRange(possibleTargets[i]) == true && possibleTargets[i].Team != 2)
            {
                Combat(possibleTargets[i]);
            }
        }
    }

}
