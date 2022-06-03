using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;
        UpdateHealthBar();

    }

    // Update is called once per frame
    void Update()
    {
        //Enables visable healthbar is the players health is above 0 and below the max health value.
        if (currentHealth == maxHealth || currentHealth <= 0)
        {
            healthSlider.gameObject.SetActive(false);
        }
        else
        {
            healthSlider.gameObject.SetActive(true);
        }
        //Stops health from falling below 0.
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
    //Takes Damage when called from Enemy Script.
    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            healthSlider.gameObject.SetActive(false);
            gameObject.GetComponent<Enemy>().alive = false;
        }
        UpdateHealthBar();
    }
    //Updates visable healthbar.
        private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }
}
