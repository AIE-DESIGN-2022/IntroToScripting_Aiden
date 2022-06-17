using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject tun;
    public GameObject left;
    public GameObject right;
    public GameObject t;
    public GameObject u;
    private bool checkOne;
    private bool checkTwo;
    private bool checkThree;
    private float rando;
    public bool triggerOneCollided;
    public bool triggerTwoCollided;
    public bool triggerThreeCollided;
    private float startTime;
    public GenerationManager manager;
    private bool generating;
    public float pieceCount;
    public float maxCount;
    public GameObject objectToDefine;
    public GameObject parent;
    public List<Vector3> pieceLocations;
    public List<GameObject> locationDict;
    private Vector3 pieceOnePosition;
    private Vector3 pieceTwoPosition;
    private Vector3 pieceThreePosition;
    private float pieceOneRotation;
    private float pieceTwoRotation;    
    private float pieceThreeRotation;
    private Color randoColor;

    // Start is called before the first frame update
    void Awake()
    {
        checkOne = true;
        checkTwo = true;
        checkThree = true;
        startTime = Time.time;
        triggerOneCollided = false;
        triggerTwoCollided = false;
        triggerThreeCollided = false;
        manager = FindObjectOfType<GenerationManager>();
        parent = GameObject.FindGameObjectWithTag("Parent");
        generating = true;
        maxCount = manager.maxPieces;
        if (manager.colour)
        {
            RandomiseColor();
        }
        if (gameObject.tag == "Tunnel")
        {
            pieceOnePosition = new Vector3(-7, 0, 0);
            pieceTwoPosition = new Vector3(7, 0, 0);
            pieceThreePosition = new Vector3(0, 0, 0);
            pieceOneRotation = 180;
            pieceTwoRotation = 0;
            pieceThreeRotation = 0;
        }
        if (gameObject.tag == "Right")
        {
            pieceOnePosition = new Vector3(-7, 0, 0);
            pieceTwoPosition = new Vector3(0, 0, -7);
            pieceThreePosition = new Vector3(0, 0, 0);
            pieceOneRotation = 180;
            pieceTwoRotation = 90;
            pieceThreeRotation = 0;
        }
        if (gameObject.tag == "Left")
        {
            pieceOnePosition = new Vector3(0, 0, 7);
            pieceTwoPosition = new Vector3(-7, 0, 0);
            pieceThreePosition = new Vector3(0, 0, 0);
            pieceOneRotation = -90;
            pieceTwoRotation = 180;
            pieceThreeRotation = 0;
        }
        if (gameObject.tag == "T")
        {
            pieceOnePosition = new Vector3(-7, 0, 0);
            pieceTwoPosition = new Vector3(0, 0, 7);
            pieceThreePosition = new Vector3(0, 0, -7);
            pieceOneRotation = 0;
            pieceTwoRotation = -90;
            pieceThreeRotation = 90;
        }
    }

    // Update is called once per frame
    void Update()
    {
        pieceCount = manager.count;
        if (Time.time > startTime + 0.05F && generating == true && Time.timeSinceLevelLoad > 1)
        {
            if (checkOne == true && !triggerOneCollided)
            {
                manager.generationTime = Time.time;
                DeclairRando();
                CreateNextMazeOne(objectToDefine);
            }
            if (checkTwo == true && !triggerTwoCollided)
            {
                manager.generationTime = Time.time;
                DeclairRando();
                CreateNextMazeTwo(objectToDefine);
            }
            if (checkThree == true && !triggerThreeCollided)
            {
                manager.generationTime = Time.time;
                DeclairRando();
                CreateNextMazeThree(objectToDefine);
            }
        }
        if (triggerOneCollided && triggerTwoCollided && triggerThreeCollided)
        {
            generating = false;
        }
    }
    public void CreateNextMazeOne(GameObject obj)
    {
        GameObject PieceOne = Instantiate(obj, transform.position, Quaternion.identity);
        PieceOne.transform.position = gameObject.transform.position;
        PieceOne.transform.rotation = gameObject.transform.rotation;
        PieceOne.transform.parent = gameObject.transform;
        PieceOne.transform.Rotate(0, pieceOneRotation, 0);
        PieceOne.transform.localPosition = pieceOnePosition;
        PieceOne.transform.parent = parent.transform;
        AddToLists(PieceOne);
        checkOne = false;
    }
    public void CreateNextMazeTwo(GameObject obj)
    {
        GameObject PieceTwo = Instantiate(obj, transform.position, Quaternion.identity);
        PieceTwo.transform.position = gameObject.transform.position;
        PieceTwo.transform.rotation = gameObject.transform.rotation;
        PieceTwo.transform.parent = gameObject.transform;
        PieceTwo.transform.Rotate(0, pieceTwoRotation, 0);
        PieceTwo.transform.localPosition = pieceTwoPosition;
        PieceTwo.transform.parent = parent.transform;
        AddToLists(PieceTwo);
        checkTwo = false;
    }
    public void CreateNextMazeThree(GameObject obj)
    {
        GameObject PieceThree = Instantiate(obj, transform.position, Quaternion.identity);
        PieceThree.transform.position = gameObject.transform.position;
        PieceThree.transform.rotation = gameObject.transform.rotation;
        PieceThree.transform.parent = gameObject.transform;
        PieceThree.transform.Rotate(0, pieceThreeRotation, 0);
        PieceThree.transform.localPosition = pieceThreePosition;
        PieceThree.transform.parent = parent.transform;
        AddToLists(PieceThree);
        checkThree = false;
    }
        public void DeclairRando()
    {
        if (pieceCount < maxCount)
        {
            rando = Random.Range(0, 100);
            if (Time.timeSinceLevelLoad < 20)
            {
                if (rando >= 0 && rando <= 30)
                {
                    objectToDefine = tun;
                }
                if (rando >= 31 && rando <= 50)
                {
                    objectToDefine = right;
                }
                if (rando >= 51 && rando <= 70)
                {
                    objectToDefine = left;
                }
                if (rando >= 71 && rando <= 100)
                {
                    objectToDefine = t;
                }
            }
            else
            {
                if (rando >= 0 && rando <= 20)
                {
                    objectToDefine = tun;
                }
                if (rando >= 21 && rando <= 50)
                {
                    objectToDefine = right;
                }
                if (rando >= 51 && rando <= 80)
                {
                    objectToDefine = left;
                }
                if (rando >= 81 && rando <= 100)
                {
                    objectToDefine = t;
                }
            }
        }
        else
        {
            objectToDefine = u;
        }
    }
    public void AddToLists(GameObject objectToAdd)
    {
        manager.CheckForOverlaps(objectToAdd);
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

