using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthClass : MonoBehaviour
{
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private bool invincible = false;
    public bool Invincible
    {
        get {return invincible;}
        set {invincible = value;}
    }
    private float iTime = 0f;
    public float ITime
    {
        get {return iTime;}
        set {iTime = value;}
    }
    private float maxIframes = 1f;
    public float MaxIframes
    {
        get{return maxIframes;}
        set{maxIframes = value;}
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
    
    public void iFrames()
    {
        iTime -= Time.deltaTime;
        if (iTime <= 0) 
        {
            invincible = false;
            Debug.Log("Turn off iFrames");
        }
    }
}
