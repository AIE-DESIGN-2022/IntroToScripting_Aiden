using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Telephone : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

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
