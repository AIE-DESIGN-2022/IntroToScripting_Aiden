using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UScript : MonoBehaviour
{
    private Color randoColor;
    public GenerationManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GenerationManager>();
        if (manager.colour)
        {
            RandomiseColor();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RandomiseColor()
    {
        randoColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        GetComponent<MeshRenderer>().material.color = randoColor;
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = randoColor;
        }
    }
}
