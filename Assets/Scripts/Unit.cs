using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Unit : MonoBehaviour
{
    //Variable declarations
    protected int faction;
    protected bool isAttacking;
    protected int health;
    protected int maxHealth;
    protected int speed;
    protected int attack;
    protected int attackRange;
    protected string type;
    private Random rng = new Random();


    //Accessors for the variables
    
    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; }
    public int Speed { get => speed; set => speed = value; }
    public int Attack { get => attack; set => attack = value; }
    public int AttackRange { get => attackRange; set => attackRange = value; }
    public int Faction { get => faction; set => faction = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public string Type { get => type; set => type = value; }

    public Unit(int faction, int health, int maxHealth, int speed, int attack, int attackRange)
    {
        this.faction = faction;
        this.isAttacking = false;
        this.health = health;
        this.maxHealth = maxHealth;
        this.speed = speed;
        this.attack = attack;
        this.attackRange = attackRange;
        this.type = "Unit";

    }

    public void Combat()
    {

    }

    public void AttackingRange()
    {

    }

    public void ClosestEnemy()
    {

    }

    public void Death()
    {

    }

    public override string ToString()
    {
        return base.ToString();
    }

    public void Movement()
    {
        
    }
}
