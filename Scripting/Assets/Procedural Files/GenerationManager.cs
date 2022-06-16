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
    public NavMeshSurface[] surfaces;
    public List<Vector3> colliderLocations;
    public Counter counter;
    public List<GameObject> pieces;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pleaseWait = GameObject.FindGameObjectWithTag("Wait");
        counter = FindObjectOfType<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
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
    public void DisableAllTriggers()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].gameObject.SetActive(false);
        }
    }
    public void EnableAllTriggers()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].gameObject.SetActive(true);
        }
    }

    public void BakeNav()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
    public void AddToList()
    {
        
    }

    /*public bool AddToList(Vector3 positionOfObject)
    {
        foreach(Vector3 pos in colliderLocations)
        {
            if(positionOfObject == pos)
            {
                return true;
            }
            
        }
        colliderLocations.Add(positionOfObject);
        return false;

    }*/
}
