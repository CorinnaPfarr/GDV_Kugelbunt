using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem {

    private int health;
    public int healthMax = 9;


    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        this.health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Heal(int healthAmount)
    {
        health += healthAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
    }

    

}
