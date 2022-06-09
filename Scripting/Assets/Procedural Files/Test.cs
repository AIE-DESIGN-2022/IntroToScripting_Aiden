using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject cube;
    public bool check;
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
            GameObject Created = Instantiate(cube, transform.localPosition, Quaternion.identity);
            Created.transform.rotation = gameObject.transform.rotation;
            Created.transform.parent = gameObject.transform;
            Created.transform.localPosition = new Vector3(1, 0, 0);
            check = false;
        }

    }
}
