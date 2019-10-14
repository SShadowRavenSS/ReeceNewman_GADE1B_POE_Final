using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeUnit : Unit
{

    public MeleeUnit(int faction, int health, int maxHealth, int speed, int attack, int attackRange) : base(faction, health, maxHealth, speed, attack, attackRange)
    {
       

    }
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider temp = GetComponent<BoxCollider>();
        temp.size = new Vector3(5,1,5);
        
    }

    // Update is called once per frame
    void Update()
    {
        Logic();

        //BoxCollider temp = GetComponent<BoxCollider>();
        //lDebug.Log(temp.size);
    }

    
}
