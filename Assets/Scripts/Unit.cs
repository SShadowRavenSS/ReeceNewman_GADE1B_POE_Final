using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Unit : MonoBehaviour
{
    //Variable declarations
    protected int faction;
    protected bool isAttacking;
    [SerializeField]
    protected float health;
    protected float maxHealth;
    [SerializeField]
    protected float speed;
    protected float attack;
    [SerializeField]
    protected float attackRange;
    protected string type;
    private Random rng = new Random();
    protected bool isInRange;
    [SerializeField] protected Material[] mat;
    [SerializeField] protected int team;

    //Accessors for the variables

    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => maxHealth; }
    public float Speed { get => speed; set => speed = value; }
    public float Attack { get => attack; set => attack = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public int Faction { get => faction; set => faction = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public string Type { get => type; set => type = value; }

    

    protected void Combat(Unit unitToAttack)
    {

        unitToAttack.health -= this.attack;

        Debug.Log("Attttttttack!!!!  Health Remaining: " + unitToAttack.health);
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
        //Debug.Log("It works");
    }

    //returns the closest unit to the current unit
    protected Unit ClosestUnit(Unit[] units)
    {
        float lowestDist = int.MaxValue;
        float closestUnit = int.MaxValue;
        int thisUnit = 0;

        //runs a loop through all the units in the array
        for (int k = 0; k < units.Length; k++)
        {
            //checks that the unit is not dead
            if (units[k].IsDead() == false)
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
                    }

                }
                else
                {
                    thisUnit = k;
                }

            }

        }
        //check to ensure integrety of code by returning either this unit or the closest unit determined
        if (closestUnit != int.MaxValue)
        {
            //Debug.Log(units[(int)closestUnit].transform.position);
            Debug.DrawLine(this.transform.position, units[(int)closestUnit].transform.position);
            return units[(int)closestUnit];
            
        }
        else
        {
            //Debug.Log(units[(int)closestUnit].transform.position);
            return units[thisUnit];
        }

    }


    public override string ToString()
    {
        string output = "";
        return output;
    }

    protected void Logic()
    {
        Unit[] units = GameObject.FindObjectsOfType<Unit>();

        Movement(ClosestUnit(units));

        if(isInRange == true)
        {
            Unit unitToAttack = ClosestUnit(units);
            Combat(unitToAttack);
        }

        if(IsDead() == true)
        {
            Destroy(gameObject);
        }
        

    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            isInRange = true;    
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if(other.tag == "Unit")
        {
            isInRange = false;
        }
    }
}
