using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Telephone : MonoBehaviour
{
    public EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.telephonesList.Add(this.transform);
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
            if (other.gameObject.GetComponent<Enemy>().alerted == true)
            {
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }
}
