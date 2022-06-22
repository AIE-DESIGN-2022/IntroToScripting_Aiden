using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GenerationManager : MonoBehaviour
{
    public float generationTime;
    public GameObject firstTunnel;
    public float delay;
    public GameObject[] triggers;
    public GameObject[] enemies;
    public GameObject player;
    private bool check;
    private bool checkTwo;
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
    public GameObject telephone;
    private int randoSpawn;
    public GameObject scoring;
    public GameObject hudStuff;
    public GameObject timehud;
    private float piecesToSpawn;
    private float enemiesToSpawn;
    private float telephonesToSpawn;
    public EnemyManager enemyManager;
    public float telephoneNames;

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
        telephoneNames = 0;
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
            InstantiateTelephone();
            InstantiateObjective();
            InstantiateEnemies();
            HudStuff();
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
        piecesForSpawning.RemoveAt(0);
        piecesToSpawn = pieceLocations.Count / 100;
        enemiesToSpawn = pieceLocations.Count / 50;
        telephonesToSpawn = pieceLocations.Count / 50;
        checkTwo = true;
    }
    public void InstantiateObjective()
    {
        if (piecesToSpawn > 0)
        {
            randoSpawn = Random.Range(10, piecesForSpawning.Count);
            GameObject obj = Instantiate(objective, transform.position, Quaternion.identity);
            obj.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 1.0F, piecesForSpawning[randoSpawn].z);
            piecesForSpawning.RemoveAt(randoSpawn);
            piecesToSpawn--;
            InstantiateObjective();
        }
    }
    //continue from here you idiot
    public void InstantiateEnemies()
    {
        if (enemiesToSpawn > 0)
        {
            randoSpawn = Random.Range(10, piecesForSpawning.Count);
            GameObject enm = Instantiate(enemy, transform.position, Quaternion.identity);
            enm.transform.GetChild(0).transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 2.0F, piecesForSpawning[randoSpawn].z);
            enm.transform.GetChild(0).GetComponent<Navigation>().DeclairPhones();
            enm.transform.GetChild(1).transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 2.0F, piecesForSpawning[randoSpawn].z);
            enm.transform.GetChild(2).transform.position = new Vector3(piecesForSpawning[randoSpawn + 5].x, 2.0F, piecesForSpawning[randoSpawn + 5].z);
            enm.transform.GetChild(3).transform.position = new Vector3(piecesForSpawning[randoSpawn - 5].x, 2.0F, piecesForSpawning[randoSpawn - 5].z);
            piecesForSpawning.RemoveAt(randoSpawn);
            piecesForSpawning.RemoveAt(randoSpawn + 5);
            piecesForSpawning.RemoveAt(randoSpawn - 5);
            enemiesToSpawn--;
            InstantiateEnemies();
        }
    }
    public void InstantiateTelephone()
    {
        if (telephonesToSpawn > 0)
        {
            randoSpawn = Random.Range(10, piecesForSpawning.Count);
            GameObject obj = Instantiate(telephone, transform.position, Quaternion.identity);
            obj.name = "Telephone" + telephoneNames;
            obj.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 1.0F, piecesForSpawning[randoSpawn].z);
            enemyManager.telephonesList.Add(obj.transform);
            piecesForSpawning.RemoveAt(randoSpawn);
            telephonesToSpawn--;
            telephoneNames++;
            InstantiateTelephone();
        }
    }
    public void HudStuff()
    {
        scoring.gameObject.SetActive(true);
        hudStuff.gameObject.SetActive(true);
        timehud.gameObject.SetActive(true);
        pleaseWait.SetActive(false);
    }
}

