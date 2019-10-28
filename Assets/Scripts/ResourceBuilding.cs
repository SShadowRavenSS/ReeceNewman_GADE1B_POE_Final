using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    //variable declarations
    private int resourcePoolRemaining, generatedResources, resourcesPerRound, maxPool;
    private float timer;

    

    // Start is called before the first frame update
    void Start()
    {
        maxPool = 100;
        resourcesPerRound = 2;
        generatedResources = 0;
        resourcePoolRemaining = 100;
        health = 100;
        maxHealth = health;
        faction = Random.Range(0, 2);

        GetComponent<MeshRenderer>().material = mat[Faction];

        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = (float)health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 1f)
        {
            GameEngine temp = GameObject.FindObjectOfType<GameEngine>();
            if(faction == 0)
            {
                temp.Team1Resources += GenerateResources();

            }
            else
            {
                temp.Team2Resources += GenerateResources();
            }
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    public int GenerateResources()
    {
        int amountProduced = 0;

        //check to make sure there are still resources left
        if (resourcePoolRemaining != 0)
        {
            //checks if the pool will still have resources left after generating resources
            if (resourcePoolRemaining - resourcesPerRound < 0)
            {
                //adds the pool if it is less than zero and makes pool equal zero
                generatedResources += resourcePoolRemaining;
                amountProduced += resourcePoolRemaining;
                resourcePoolRemaining = 0;
            }
            else
            {
                //adds the per round production if it is more than zero and subtracts the amount from the pool
                generatedResources += resourcesPerRound;
                amountProduced += resourcesPerRound;
                resourcePoolRemaining -= resourcesPerRound;
            }
        }

        return amountProduced;

    }


}
