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
    private float randoMin;
    private float randoMinTwo;
    private float randoMinThree;
    private float randoMax;
    private float randoMaxTwo;
    private float randoMaxThree;
    public GameObject scoring;
    public GameObject hudStuff;
    public GameObject timehud;
    private float piecesToSpawn;
    private float enemiesToSpawn;
    private float telephonesToSpawn;
    public EnemyManager enemyManager;
    public float telephoneNames;
    public GameObject parent;
    public ManagerManager managerManager;
    public ArrowPointy arrowPointy;
    public GameObject overviewCamera;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Awake()
    {
        pleaseWait = GameObject.FindGameObjectWithTag("Wait");
        parent = GameObject.FindGameObjectWithTag("Parent2");
        managerManager = FindObjectOfType<ManagerManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        arrowPointy = FindObjectOfType<ArrowPointy>();
        colourChance = Random.Range(0, 1000);
        if (colourChance == 777)
        {
            colour = true;
        }
        locationDict.Add(firstTunnel);
        pieceLocations.Add(firstTunnel.transform.position);
        telephoneNames = 0;
        if (managerManager.level == 0)
        {
            managerManager.level = 1;
        }
        maxPieces = managerManager.level * 100;
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
        player.transform.position = new Vector3 (pieceLocations[0].x, pieceLocations[0].y + 1, pieceLocations[0].z);
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
        if (pieceLocations.Count < maxPieces)
        {
            SceneManager.LoadScene("Maze");
        }
        piecesForSpawning.RemoveAt(0);
        piecesToSpawn = pieceLocations.Count / 100;
        enemiesToSpawn = pieceLocations.Count / 50;
        telephonesToSpawn = pieceLocations.Count / 50;
        randoMin = 0.10F;
        randoMinTwo = 0.10F;
        randoMinThree = 0.10F;
        randoMax = 0.20F;
        randoMaxTwo = 0.20F;
        randoMaxThree = 0.20F;
    }
    public void InstantiateObjective()
    {
        if (piecesToSpawn > 0)
        {
            randoSpawn = Random.Range((int)Mathf.Round(piecesForSpawning.Count * randoMin), (int)Mathf.Round(piecesForSpawning.Count * randoMax));
            GameObject obj = Instantiate(objective, transform.position, Quaternion.identity);
            obj.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 1.0F, piecesForSpawning[randoSpawn].z);
            obj.transform.parent = parent.transform;
            piecesForSpawning.RemoveAt(randoSpawn);
            piecesToSpawn--;
            randoMin = randoMin + 0.10F;
            randoMax = randoMax + 0.10F;
            if (randoMax > 1)
            {
                randoMin = 0.10F;
                randoMax = 0.20F;
            }
            InstantiateObjective();
        }
    }
    public void InstantiateEnemies()
    {
        if (enemiesToSpawn > 0)
        {
            randoSpawn = Random.Range((int)Mathf.Round(piecesForSpawning.Count * randoMinTwo), (int)Mathf.Round(piecesForSpawning.Count * randoMaxTwo));
            GameObject enm = Instantiate(enemy, transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 2.0F, piecesForSpawning[randoSpawn].z), Quaternion.identity);
            enm.transform.GetChild(0).GetComponent<Navigation>().DeclairPhones();
            enm.transform.GetChild(0).GetComponent<Navigation>().SetAgentDestination();
            enm.transform.GetChild(1).transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 2.0F, piecesForSpawning[randoSpawn].z);
            enm.transform.GetChild(2).transform.position = new Vector3(piecesForSpawning[randoSpawn + 5].x, 2.0F, piecesForSpawning[randoSpawn + 5].z);
            enm.transform.parent = parent.transform;
            if (randoSpawn - 5 < 0)
            {
                enm.transform.GetChild(3).transform.position = new Vector3(piecesForSpawning[randoSpawn + 1].x, 2.0F, piecesForSpawning[randoSpawn + 1].z);
            }
            else
            {
                enm.transform.GetChild(3).transform.position = new Vector3(piecesForSpawning[randoSpawn - 5].x, 2.0F, piecesForSpawning[randoSpawn - 5].z);
            }
            piecesForSpawning.RemoveAt(randoSpawn);
            piecesForSpawning.RemoveAt(randoSpawn + 5);
            piecesForSpawning.RemoveAt(randoSpawn - 5);
            enemiesToSpawn--;
            randoMinTwo = randoMinTwo + 0.10F;
            randoMaxTwo = randoMaxTwo + 0.10F;
            if (randoMaxTwo > 1)
            {
                randoMinTwo = 0.10F;
                randoMaxTwo = 0.20F;
            }
            InstantiateEnemies();
        }
    }
    public void InstantiateTelephone()
    {
        if (telephonesToSpawn > 0)
        {
            randoSpawn = Random.Range((int)Mathf.Round(piecesForSpawning.Count * randoMinThree), (int)Mathf.Round(piecesForSpawning.Count * randoMaxThree));
            GameObject obj = Instantiate(telephone, transform.position, Quaternion.identity);
            obj.name = "Telephone" + telephoneNames;
            obj.transform.position = new Vector3(piecesForSpawning[randoSpawn].x, 1.0F, piecesForSpawning[randoSpawn].z);
            enemyManager.telephonesList.Add(obj.transform);
            obj.transform.parent = parent.transform;
            piecesForSpawning.RemoveAt(randoSpawn);
            telephonesToSpawn--;
            telephoneNames++;
            randoMinThree = randoMinThree + 0.10F;
            randoMaxThree = randoMaxThree + 0.10F;
            if (randoMaxThree > 1)
            {
                randoMinThree = 0.10F;
                randoMaxThree = 0.20F;
            }
            InstantiateTelephone();
        }
    }
    public void HudStuff()
    {
        scoring.gameObject.SetActive(true);
        hudStuff.gameObject.SetActive(true);
        timehud.gameObject.SetActive(true);
        //pleaseWait.SetActive(false);
        overviewCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
        

    }
}

