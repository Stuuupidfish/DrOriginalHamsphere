using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthClass : MonoBehaviour
{
    public int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("DEAD");
        //PLACEHOLDER BECAUSE DEATH NOT IMPLEMENTED YET
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
