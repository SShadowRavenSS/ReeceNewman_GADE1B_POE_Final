using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBuilding : Building
{
    private string unitType;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0,2) == 0)
        {
            unitType = "RangedUnit";
        }
        else
        {
            unitType = "MeleeUnit";
        }

        faction = Random.Range(0, 2);
        health = 100;
        maxHealth = health;
        GetComponent<MeshRenderer>().material = mat[faction];

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 10f)
        {
            SpawnUnits();
            timer = 0f;
        }
        timer += Time.deltaTime;

        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = (float)health / maxHealth;
    }

    public void SpawnUnits()
    {
        //checks this buildings faction
        int team = this.faction;

        //checks if the building is producing ranged or melee units 
        if (this.unitType == "RangedUnit")
        {
            //based on the team it is in, it creates the unit
            if (team == 0)
            {
                GameObject createdUnit = Instantiate(unitOptions[1]);
                createdUnit.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, transform.position.z);
                createdUnit.tag = "Team1";
                createdUnit.GetComponent<MeshRenderer>().material = mat[team];

            }
            else
            {
                GameObject createdUnit = Instantiate(unitOptions[1]);
                createdUnit.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, transform.position.z);
                createdUnit.tag = "Team2";
                createdUnit.GetComponent<MeshRenderer>().material = mat[team];
            }

        }
        else
        {
            //based on the team it is in, it creates the unit
            if (team == 0)
            {
                GameObject createdUnit = Instantiate(unitOptions[0]);
                createdUnit.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, transform.position.z);
                createdUnit.tag = "Team1";
                createdUnit.GetComponent<MeshRenderer>().material = mat[team];
            }
            else
            {
                GameObject createdUnit = Instantiate(unitOptions[0]);
                createdUnit.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, transform.position.z);
                createdUnit.tag = "Team2";
                createdUnit.GetComponent<MeshRenderer>().material = mat[team];
            }
        }


    }

    
}
