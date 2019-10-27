using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Unit : MonoBehaviour
{
    //Variable declarations
    protected bool isAttacking;
    [SerializeField]
    protected int health;
    protected int maxHealth;
    [SerializeField]
    protected float speed;
    protected int attack;
    [SerializeField]
    protected float attackRange;
    protected string type;
    private Random rng = new Random();
    [SerializeField] protected Material[] mat;
    [SerializeField] protected int team;
    protected float timer = 0f;
    [SerializeField]
    protected Image healthBar;


    //Accessors for the variables

    
    public float MaxHealth { get => maxHealth; }
    public float Speed { get => speed; set => speed = value; }   
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public string Type { get => type; set => type = value; }
    public int Health { get => health; set => health = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Team { get => team; set => team = value; }

    void Update()
    {
        Logic();

        //BoxCollider temp = GetComponent<BoxCollider>();
        //lDebug.Log(temp.size);

        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = (float)health/maxHealth;

        if(gameObject.tag == "Team1")
        {
            team = 0;
        }
        else if(gameObject.tag == "Team2")
        {
            team = 1;
        }

        gameObject.GetComponent<MeshRenderer>().material = mat[team];
    }

    protected void Combat(Unit unitToAttack)
    {
        if(unitToAttack != this)
        {
            unitToAttack.health -= this.attack;
        }
        

       // Debug.Log("Attttttttack!!!!  Health Remaining: " + unitToAttack.health);
    }

    protected void Combat(Building unitToAttack)
    {
        if (unitToAttack != this)
        {
            unitToAttack.Health -= this.attack;
        }


        Debug.Log("Attttttttack!!!!  Health Remaining: " + unitToAttack.Health);
    }

    protected bool IsDead()
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

    protected void Movement(Unit moveTowards)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveTowards.transform.position, speed*Time.deltaTime);
        
    }

    protected void Movement(Building moveTowards)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveTowards.transform.position, speed * Time.deltaTime);
        
    }

    //returns the closest unit to the current unit
    protected Unit ClosestUnit(Unit[] units)
    {
        float lowestDist = int.MaxValue;
        float closestUnit = int.MaxValue;
        Unit returnedUnit = null;

        //runs a loop through all the units in the array
        for (int k = 0; k < units.Length; k++)
        {
            //checks that the unit is not dead
            if (units[k].IsDead() == false)
            {
                if(units[k].team != this.team)
                {

                    //determines the distance of the unit
                    float dist = Vector3.Distance(units[k].transform.position, this.transform.position);
                    //Debug.Log(dist);

                    if (this != units[k]) //checks if the unit it is checking is not itself
                    {
                        //checks if the unit is closer than any other previous unit and if so saves that units index and distance
                        if (dist < lowestDist)
                        {
                            lowestDist = dist;
                            closestUnit = k;
                            returnedUnit = units[k];
                        }

                    }
                    else
                    {
                        
                    }
                }

            }

        }
        if(returnedUnit != null)
        {
            Debug.DrawLine(this.transform.position, returnedUnit.transform.position);
        }
        
        return returnedUnit;

    }

    protected Building ClosestUnit(Building[] units)
    {
        float lowestDist = int.MaxValue;
        float closestUnit = int.MaxValue;
        
        Building returnedUnit = null;

        //runs a loop through all the units in the array
        for (int k = 0; k < units.Length; k++)
        {
            //checks that the unit is not dead
            if (units[k].Death() == false)
            {
                if (units[k].Faction != this.team)
                {

                    //determines the distance of the unit
                    float dist = Vector3.Distance(units[k].transform.position, this.transform.position);
                    //Debug.Log(dist);

                    if (this != units[k]) //checks if the unit it is checking is not itself
                    {
                        //checks if the unit is closer than any other previous unit and if so saves that units index and distance
                        if (dist < lowestDist)
                        {
                            lowestDist = dist;
                            closestUnit = k;
                            returnedUnit = units[k];
                        }

                    }
                    else
                    {
                        
                    }
                }

            }

        }
        if (returnedUnit != null)
        {
            Debug.DrawLine(this.transform.position, returnedUnit.transform.position);
        }
        return returnedUnit;

    }


    public override string ToString()
    {
        string output = "";
        return output;
    }

    protected void Logic()
    {
        Unit[] units = GameObject.FindObjectsOfType<Unit>();
        Building[] buildings = GameObject.FindObjectsOfType<Building>();

        if(timer > 0.1f)
        {

            if (IsDead() == true)
            {
                Destroy(gameObject);
            }
            Unit unitToAttack = ClosestUnit(units);
            Building buildToAttack = ClosestUnit(buildings);

            if(unitToAttack != null && buildToAttack != null && Vector3.Distance(gameObject.transform.position, buildToAttack.transform.position) > Vector3.Distance(gameObject.transform.position, unitToAttack.transform.position))
            {
                if (this is WizardUnits)
                {
                    if (AoeAttack(units) == false)
                    {
                        if (team != unitToAttack.Team)
                        {
                            Movement(unitToAttack);
                        }

                    }
                    
                }
                else
                {


                    if (IsInRange(unitToAttack) == true)
                    {
                        if (unitToAttack != this && unitToAttack.Team != team && unitToAttack != null)
                        {
                            Combat(unitToAttack);
                        }

                        if (unitToAttack.health <= 0)
                        {
                            Destroy(unitToAttack.gameObject);

                        }
                    }
                    else
                    {
                        if (unitToAttack.Team != team && unitToAttack != null)
                        {
                            Movement(ClosestUnit(units));
                        }

                    }
                }
                
            }
            else
            {
                if (this is WizardUnits)
                {
                    if (AoeAttack(units) == false)
                    {
                        if (team != unitToAttack.Team)
                        {
                            Movement(unitToAttack);
                        }

                    }

                }
                else
                {
                    if (buildToAttack.Faction != team && buildToAttack != null)
                    {
                        if (IsInRange(buildToAttack) == true && unitToAttack != null)
                        {
                         

                            if (buildToAttack.Faction != team)
                            {
                                Combat(buildToAttack);
                            }

                            if (buildToAttack.Health <= 0)
                            {
                                Destroy(buildToAttack.gameObject);

                            }
                        }
                        else
                        {
                           
                            Movement(ClosestUnit(buildings));
                        }
                    }
                }
                
            }
            timer = 0f;
        }
        timer += Time.deltaTime;



    }

    protected bool IsInRange(Unit unitToAttack)
    {


        if (this.attackRange <= Vector3.Distance(this.transform.position, unitToAttack.transform.position))
        {
            return false;
        }
        else
        {
            
            return true;
        }
       
        
    }

    protected bool IsInRange(Building unitToAttack)
    {


        if (this.attackRange <= Vector3.Distance(this.transform.position, unitToAttack.transform.position))
        {
            return false;
        }
        else
        {
            
            return true;
        }


    }

    private bool AoeAttack(Unit[] possibleTargets)
    {
        bool didAttack = false;
        for (int i = 0; i < possibleTargets.Length; i++)
        {
            if (IsInRange(possibleTargets[i]) == true && possibleTargets[i].Team != 2)
            {
                Combat(possibleTargets[i]);
                didAttack = true;
            }

        }
        return didAttack;
    }


}
