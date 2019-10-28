using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour
{
    //Variable declarations
    protected int faction;
    [SerializeField] protected int health;
    protected int maxHealth;
    [SerializeField] protected Material[] mat;
    [SerializeField] protected GameObject[] unitOptions;
    protected Image healthBar;
    private int counter = 0;

    //Provide abstract method defenitions
    public bool Death()
    {
        if (this.health > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; }
    public int Faction { get => faction; }

    protected void Logic()
    {
        bool resetCounter = false;

        GameEngine ge = GameObject.FindObjectOfType<GameEngine>();
        //Checks type of building
        if (this is ResourceBuilding)
        {
            //creates temp instance of resourcebuilding
            ResourceBuilding rblding = (ResourceBuilding)this;

            //calls the generate resource method
            if(rblding.Faction == 0)
            {
                ge.Team1Resources += rblding.GenerateResources();
            }
            else
            {
                ge.Team2Resources += rblding.GenerateResources();
            }
            

        }
        else
        {
            //creates temp instance of factorybuilding
            FactoryBuilding fblding = (FactoryBuilding)this;

            //checks if the building should be generating a unit
            if (fblding.ProductionSpeed <= counter)
            {

                if (fblding.Faction == 0)
                {
                    if (ge.Team1Resources >= 5)
                    {
                        
                        fblding.SpawnUnits();
                        
                        resetCounter = true; //Set boolean to reset counter
                        ge.Team1Resources -= 5; //Pay the resource cost of producing the units
                    }

                }
                else
                {
                    if (ge.Team2Resources >= 5)
                    {
                        
                        fblding.SpawnUnits();
                        
                        resetCounter = true; //Set boolean to reset counter
                        ge.Team2Resources -= 5; //Pay the resource cost of producing the units
                    }
                }
            }
            else
            {
                //if not set boolean not to reset counter
                resetCounter = false;
            }

        }


        //checks whether counter should be reset or incrimented
        if (resetCounter == true)
        {
            resetCounter = false;
            counter = 0;
        }
        else
        {
            ++counter;

        }
    }
}
