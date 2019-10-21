using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeUnit : Unit
{

    public void Start()
    {
        BoxCollider temp = GetComponent<BoxCollider>();
        temp.size = new Vector3(3, 1, 3);

        attack = 2f;
        speed = 2f;
        health = 10f;
        team = Random.Range(1, 3);
        // GetComponent<MeshRenderer>().material = mat[team - 1];
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        Logic();

        //BoxCollider temp = GetComponent<BoxCollider>();
        //lDebug.Log(temp.size);
        healthBar.fillAmount = health / maxHealth;
    }

    
}
