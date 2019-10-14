using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Unit : MonoBehaviour
{
    //Variable declarations
    protected int faction;
    protected bool isAttacking;
    [SerializeField]
    protected float health = 10;
    protected float maxHealth = 10;
    [SerializeField]
    protected float speed =2;
    protected float attack = 2;
    [SerializeField]
    protected float attackRange;
    protected string type;
    private Random rng = new Random();


    //Accessors for the variables
    
    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => maxHealth; }
    public float Speed { get => speed; set => speed = value; }
    public float Attack { get => attack; set => attack = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public int Faction { get => faction; set => faction = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public string Type { get => type; set => type = value; }

    public Unit(int faction, int health, int maxHealth, int speed, int attack, int attackRange)
    {
        
        this.faction = faction;
        this.isAttacking = false;
        this.health = 10f;
        this.maxHealth = 10f;
        this.speed = 2f;
        this.attack = 2f;
        this.attackRange = 5f;
        this.type = "Unit";

        
    }

    public void Combat(Unit unitToAttack)
    {

        unitToAttack.health -= this.attack;

        Debug.Log("Attttttttack!!!!");
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

    public void IsInRange()
    {

        
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

        
    
        


    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Unit")
        {
            other.gameObject.GetComponent<Unit>().Health -= this.attack;
            Debug.Log(other.gameObject.GetComponent<Unit>().Health);
            
        }
    }
}
