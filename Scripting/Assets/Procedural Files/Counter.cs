using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject[] rightPieces;
    public GameObject[] leftPieces;
    public GameObject[] tunnelPieces;
    public GameObject[] tPieces;
    public float count;
    public float maxPieces;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightPieces = GameObject.FindGameObjectsWithTag("Right");
        leftPieces = GameObject.FindGameObjectsWithTag("Left");
        tunnelPieces = GameObject.FindGameObjectsWithTag("Tunnel");
        tPieces = GameObject.FindGameObjectsWithTag("T");
        count = rightPieces.Length + leftPieces.Length + tunnelPieces.Length + tPieces.Length;
    }
    public void CheckForOverlaps()
    {

    }

}
