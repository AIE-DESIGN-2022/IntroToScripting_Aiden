using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAI : MonoBehaviour
{
    public float speed;
    public float rotation;
    public float x;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        rotation = speed * 30;
    }

    // Update is called once per frame
    void Update()
    {
        float z = 1;
        Vector3 movement = new Vector3(0, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateRotation();
        }
    }

    public void UpdateRotation()
    { 
            x = Random.Range(0, 360);
            transform.Rotate(new Vector3(0, x, 0));
    }

}
