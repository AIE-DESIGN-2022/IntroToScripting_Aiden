using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Deals damage when colliding with enemy.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            //transform.parent.parent.position = other.transform.position;
        }
    }
}
