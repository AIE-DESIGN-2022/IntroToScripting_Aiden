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
    public GameObject manager;
    private bool generating;
    public GameObject counter;
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
        manager = GameObject.FindGameObjectWithTag("Manager");
        counter = GameObject.FindGameObjectWithTag("Counter");
        parent = GameObject.FindGameObjectWithTag("Parent");
        generating = true;
        maxCount = counter.GetComponent<Counter>().maxPieces;
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
        pieceCount = counter.GetComponent<Counter>().count;
        if (generating == true && Time.timeSinceLevelLoad > 1)
        {
            if (Time.time > startTime + 0.05F)
            {
                if (checkOne == true && !triggerOneCollided)
                {
                    manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                    DeclairRando();
                    CreateNextMazeOne(objectToDefine);
                }
                if (Time.time > startTime + 0.05F)
                {
                    if (checkTwo == true && !triggerTwoCollided)
                    {
                        manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                        DeclairRando();
                        CreateNextMazeTwo(objectToDefine);
                    }
                }
                if (Time.time > startTime + 0.5F)
                {
                    if (checkThree == true && !triggerThreeCollided)
                    {
                        manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                        DeclairRando();
                        CreateNextMazeThree(objectToDefine);
                    }
                }
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
            rando = Random.Range(0, 4);
            if (rando == 0)
            {
                objectToDefine = tun;
            }
            if (rando == 1)
            {
                objectToDefine = right;
            }
            if (rando == 2)
            {
                objectToDefine = left;
            }
            if (rando == 3)
            {
                objectToDefine = t;
            }
        }
        else
        {
            objectToDefine = u;
        }
    }
    public void AddToLists(GameObject objectToAdd)
    {
        counter.GetComponent<Counter>().CheckForOverlaps(objectToAdd);
    }

}

