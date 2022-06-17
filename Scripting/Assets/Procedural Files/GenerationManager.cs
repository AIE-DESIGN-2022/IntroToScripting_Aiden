using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerationManager : MonoBehaviour
{
    public float generationTime;
    public float delay;
    public GameObject[] triggers;
    public GameObject player;
    private bool check;
    public GameObject pleaseWait;
    public NavMeshSurface surface;
    public List<Vector3> colliderLocations;
    public List<GameObject> pieces;
    public float count;
    public float maxPieces;
    public List<Vector3> pieceLocations;
    public List<GameObject> locationDict;
    public bool checkedOne;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pleaseWait = GameObject.FindGameObjectWithTag("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        count = locationDict.Count;
        if (Time.timeSinceLevelLoad > generationTime + 2 && check == false)
        {
                DeleteAllTriggers();
                BakeNav();
        }
    }
    public void DeleteAllTriggers()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");
          for (int i = 0; i < triggers.Length; i++)
          {
            Destroy(triggers[i].gameObject);
          }
        player.transform.position = new Vector3(2, 2, -2.5F);
        pleaseWait.SetActive(false);
        check = true;
    }
    public void BakeNav()
    {
        surface.BuildNavMesh();
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
