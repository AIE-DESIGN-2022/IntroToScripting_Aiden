using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerationManager : MonoBehaviour
{
    public float generationTime;
    public GameObject[] triggers;
    public GameObject player;
    private bool check;
    public GameObject pleaseWait;
    public NavMeshSurface[] surfaces;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pleaseWait = GameObject.FindGameObjectWithTag("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > generationTime + 2 && check == false)
        {
            DeleteAllTriggers();
        }
    }
    public void DeleteAllTriggers()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");
          for (int i = 0; i < triggers.Length; i++)
          {
              Destroy(triggers[i].gameObject);
          }
        pleaseWait.SetActive(false);
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
        player.transform.position = new Vector3(45, 38, 18);
        check = true;
    }
}
