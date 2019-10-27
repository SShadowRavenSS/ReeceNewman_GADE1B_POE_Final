using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    //Variable declarations
    protected int faction;
    protected int health;
    protected int maxHealth;
    [SerializeField] protected Material[] mat;

    //Provide abstract method defenitions
    abstract public bool Death();

    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; }
    public int Faction { get => faction; }
}
