using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject cube;
    public bool check;
    public Color newColor;
    public float randoX;
    public float randoY;
    public float randoZ;
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
            randoX = Random.Range(-1, 2);
            randoY = Random.Range(-1, 2);
            randoZ = Random.Range(-1, 2);
            GameObject created = Instantiate(cube, new Vector3(transform.position.x + randoX, transform.position.y + randoY, transform.position.z + randoZ), Quaternion.identity);
            created.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            check = false;

        }

    }
}
