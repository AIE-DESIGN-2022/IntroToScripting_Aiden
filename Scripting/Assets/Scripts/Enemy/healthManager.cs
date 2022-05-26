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
        if (currentHealth == maxHealth)
        {
            healthSlider.gameObject.SetActive(false);
        }
        else if (currentHealth != maxHealth)
        {
            healthSlider.gameObject.SetActive(true);
        }
    }
    public void TakeDamage(float damageToTake)
    {
            currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
            UpdateHealthBar();
    }
        private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }
}
