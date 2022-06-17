using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerationManager : MonoBehaviour
{
    public float generationTime;
    public GameObject firstTunnel;
    public float delay;
    public GameObject[] triggers;
    public GameObject[] enemies;
    public GameObject player;
    private bool check;
    public GameObject pleaseWait;
    public NavMeshSurface surface;
    public List<Vector3> colliderLocations;
    public List<GameObject> pieces;
    public float timeSinceLoad;
    public float count;
    public float maxPieces;
    public List<Vector3> pieceLocations;
    public List<Vector3> piecesForSpawning;
    public List<GameObject> locationDict;
    public bool colour;
    private float colourChance;
    public GameObject objective;
    public GameObject enemy;
    public GameObject patrol;
    private int randoSpawn;
    public GameObject scoring;
    public GameObject hudStuff;
    private float piecesToSpawn;
    private float enemiesToSpawn;
    private float patrolsToSpawn;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pleaseWait = GameObject.FindGameObjectWithTag("Wait");
        enemyManager = FindObjectOfType<EnemyManager>();
        colourChance = Random.Range(0, 1000);
        if (colourChance == 777)
        {
            colour = true;
        }
        locationDict.Add(firstTunnel);
        pieceLocations.Add(firstTunnel.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLoad = Time.timeSinceLevelLoad;
        count = locationDict.Count;
        if (Time.timeSinceLevelLoad > generationTime + 2 && check == false)
        {
            DeleteAllTriggers();
            BakeNav();
            BeginInstantiation();
            InstantiateObjective();
            enemyManager.AddTelephones();
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
    public void BeginInstantiation()
    {
        piecesForSpawning = pieceLocations;
        piecesToSpawn = pieceLocations.Count / 100;
        enemiesToSpawn = pieceLocations.Count / 100;
    }
    public void InstantiateObjective()
    {
        if (piecesToSpawn > 0)
        {
            randoSpawn = Random.Range(0, piecesForSpawning.Count);
            GameObject obj = Instantiate(objective, transform.position, Quaternion.identity);
            obj.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 1.0F, piecesForSpawning[randoSpawn].z);
            piecesForSpawning.RemoveAt(randoSpawn);
            piecesToSpawn--;
            InstantiateObjective();
        }
        else
        {
            InstantiateEnemies();
        }
    }
    //continue from here you idiot
    public void InstantiateEnemies()
    {
        if (enemiesToSpawn > 0)
        {
            patrolsToSpawn = 2;
            randoSpawn = Random.Range(0, piecesForSpawning.Count);
            GameObject enm = Instantiate(enemy, transform.position, Quaternion.identity);
            enm.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 2.0F, piecesForSpawning[randoSpawn].z);
            piecesForSpawning.RemoveAt(randoSpawn);
            enemiesToSpawn--;
            InstantiatePatrol(enm);
            InstantiateEnemies();
        }
        else
        {
            scoring.gameObject.SetActive(true);
            hudStuff.gameObject.SetActive(true);
        }
    }
    public void InstantiatePatrol(GameObject Parent)
    {
        if (patrolsToSpawn > 0)
        {
            randoSpawn = Random.Range(0, piecesForSpawning.Count);
            GameObject pat = Instantiate(patrol, transform.position, Quaternion.identity);
            pat.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 1.0F, piecesForSpawning[randoSpawn].z);
            pat.transform.parent = Parent.transform;
            piecesForSpawning.RemoveAt(randoSpawn);
            patrolsToSpawn--;
            InstantiatePatrol(Parent);
        }
    }
}

