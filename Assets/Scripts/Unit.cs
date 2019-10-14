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


    //Accessors for the variables
    
    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => maxHealth; }
    public float Speed { get => speed; set => speed = value; }
    public float Attack { get => attack; set => attack = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public int Faction { get => faction; set => faction = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public string Type { get => type; set => type = value; }

    public void Start()
    {
        BoxCollider temp = GetComponent<BoxCollider>();
        temp.size = new Vector3(5, 1, 5);

        attack = 2f;
        speed = 2f;
        health = 10f;
    }

    public void Combat(Unit unitToAttack)
    {

        unitToAttack.health -= this.attack;

        Debug.Log("Attttttttack!!!!  Health Remaining: " + unitToAttack.health);
    }

    public bool IsDead()
    {
        return false;
    }

    public void Movement(Unit moveTowards)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveTowards.transform.position, speed*Time.deltaTime);
        //Debug.Log("It works");
    }

    //returns the closest unit to the current unit
    public Unit ClosestUnit(Unit[] units)
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
                float dist = (this.transform.position - units[k].transform.position).sqrMagnitude;
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

    public void Logic()
    {
        Unit[] units = GameObject.FindObjectsOfType<Unit>();

        Movement(ClosestUnit(units));

        if(isInRange == true)
        {
            Unit unitToAttack = ClosestUnit(units);
            Combat(unitToAttack);
        }
        





    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            isInRange = true;    
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Unit")
        {
            isInRange = false;
        }
    }
}
