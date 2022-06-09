using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject cube;
    public bool check;
    public float rando;
    public float rando2;
    public float rando3;
    // Start is called before the first frame update
    void Awake()
    {
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            rando = Random.Range(-1.0F, 1.0F);
            rando2 = Random.Range(-1.0F, 1.0F);
            rando3 = Random.Range(-1.0F, 1.0F);
            Instantiate(cube, new Vector3(transform.position.x + rando, transform.position.y + rando2, transform.position.z + rando3), Quaternion.identity);
            check = false;
     
        }

    }
}
