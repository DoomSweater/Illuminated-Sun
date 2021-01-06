using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // Current amount of player health
    public int health = 100;

    // The Canvas object with a child that is the healthbar sprite
    public RectTransform HealthBar;

    //total amount of health the player can have
    private int totalHealth;

    void Start()
    {
        if(HealthBar.pivot != new Vector2(0, 0))
        {
            print("pivot value needs to be 0,0");
        }
        
        IncreaseMaxHealth(health);
    }

    public void Heal(int healthToRecover)
    {
        if (healthToRecover + health > totalHealth)
        {
            health = totalHealth;
        }
        else
        {
            health += healthToRecover;
        }
        SetHealthBarSize();
    }

    public void TakeDamage(int damageTaken)
    {
        if (health - damageTaken <= 0)
        {
            health = 0;
            Death();
        }
        else
        {
            health -= damageTaken;
        }
        SetHealthBarSize();
    }

    private void IncreaseMaxHealth(int newMaxHealth)    //set the total health value AND resize the health bar to match
    {
        totalHealth = newMaxHealth;     // remember the default total amount of health
        SetHealthBarSize();
    }

    private void SetHealthBarSize()     //resize the health bar
    {
        HealthBar.sizeDelta = new Vector2((((float)health / (float)totalHealth)) * totalHealth, HealthBar.sizeDelta.y);
    }

    public void Death()
    {
        print("player is dead");
    }

}

