using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
   // public float startSpeed = 10f;
   // [HideInInspector]
   // public float speed;

    public float startHealth = 100;
    private float currentHealth;
    public int worth = 50;

    public GameObject deathEffect;
    private BuildManager buildManager;

    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
     //   speed = startSpeed;
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.fillAmount = currentHealth / startHealth;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        buildManager.playerCash += worth;
       // Debug.Log("You are dead");
    }
}
