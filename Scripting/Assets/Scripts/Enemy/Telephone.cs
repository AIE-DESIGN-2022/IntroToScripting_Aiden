using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Telephone : MonoBehaviour
{
    public EnemyManager enemyManager;
    public ManagerManager managerManager;
    // Start is called before the first frame update
    void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        managerManager = FindObjectOfType<ManagerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Changes to GameOver scene if the alerted enemy collides with the telephone
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<Enemy>().alerted == true && other.gameObject.GetComponent<Enemy>().alive == true)
            {
                managerManager.level = 0;
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }
}
