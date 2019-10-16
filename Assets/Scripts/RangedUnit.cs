using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : Unit
{

    public void Start()
    {
        BoxCollider temp = GetComponent<BoxCollider>();
        temp.size = new Vector3(5, 1, 5);

        attack = 2f;
        speed = 2f;
        health = 10f;
        team = Random.Range(1, 3);
        GetComponent<MeshRenderer>().material = mat[team - 1];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
