using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
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
        if (currentHealth == maxHealth || currentHealth <= 0)
        {
            healthSlider.gameObject.SetActive(false);
        }
        else
        {
            healthSlider.gameObject.SetActive(true);
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
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
        private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }
}
