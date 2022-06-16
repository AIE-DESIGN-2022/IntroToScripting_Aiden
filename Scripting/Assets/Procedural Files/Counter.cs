using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Counter : MonoBehaviour
{
    public GameObject[] rightPieces;
    public GameObject[] leftPieces;
    public GameObject[] tunnelPieces;
    public GameObject[] tPieces;
    public float count;
    public float maxPieces;
    public List<Vector3> pieceLocations;
    public List<GameObject> locationDict;// = new Dictionary<GameObject obj, Vector3 pos>;
    public bool checkedOne;

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
    public void CheckForOverlaps(GameObject objectToCheck)
    {
        bool addItem = false;
        if (!checkedOne)
        {
            pieceLocations.Add(objectToCheck.transform.position);
            locationDict.Add(objectToCheck);
            checkedOne = true;
        }
        else
        {
            foreach (Vector3 pos in pieceLocations)
            {
                if (Vector3.Distance(pos, objectToCheck.transform.position) < 0.8F)
                {
                    Debug.Log(objectToCheck);
                    Destroy(objectToCheck);
                }
                else
                {
                    addItem = true;
                }
            }
            if (addItem)
            {
                pieceLocations.Add(objectToCheck.transform.position);
                locationDict.Add(objectToCheck);
            }
        }
           
    }
        
            
}

    


