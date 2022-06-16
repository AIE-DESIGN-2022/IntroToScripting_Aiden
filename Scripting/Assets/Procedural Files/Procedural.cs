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
    public bool checkOne;
    public bool checkTwo;
    public bool checkThree;
    public float rando;
    public bool triggerOneCollided;
    public bool triggerTwoCollided;
    public bool triggerThreeCollided;
    private float startTime;
    public GameObject manager;
    private bool generating;
    public GameObject counter;
    public float pieceCount;
    public float maxCount;
    Transform spawnParent;

    public List<Vector3> pieceLocations;
    public List<GameObject> locationDict;

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
        generating = true;
        maxCount = counter.GetComponent<Counter>().maxPieces;
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
                    if (pieceCount <= maxCount)
                    {
                        CreateNextMazeOne();
                    }
                    else if (pieceCount > maxCount)
                    {
                        CreateEndMazeOne();
                    }
                }
                if (Time.time > startTime + 0.05F)
                {
                    if (checkTwo == true && !triggerTwoCollided)
                    {
                        manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                        DeclairRando();
                        if (pieceCount <= maxCount)
                        {
                            CreateNextMazeTwo();
                        }
                        else if (pieceCount > maxCount)
                        {
                            CreateEndMazeTwo();
                        }
                    }
                }
                if (Time.time > startTime + 0.5F)
                {
                    if (checkThree == true && !triggerThreeCollided)
                    {
                        manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                        DeclairRando();
                        if (pieceCount <= maxCount)
                        {
                            CreateNextMazeThree();
                        }
                        else if (pieceCount > maxCount)
                        {
                            CreateEndMazeThree();
                        }
                    }
                }
            }
        }
        if (triggerOneCollided && triggerTwoCollided && triggerThreeCollided)
        {
            generating = false;
        }
    }
    public void CreateNextMazeOne()
    {
        if (gameObject.tag == "Tunnel")
        {
            if (rando == 0)
            {
                GameObject TunOne = Instantiate(tun, transform.position, Quaternion.identity);
                TunOne.transform.position = gameObject.transform.position;
                TunOne.transform.rotation = gameObject.transform.rotation;
                TunOne.transform.parent = gameObject.transform;
                TunOne.transform.Rotate(0, 180, 0);
                TunOne.transform.localPosition = new Vector3(-7, 0, 0);
                TunOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunOne);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, 180, 0);
                RightOne.transform.localPosition = new Vector3(-7, 0, 0);
                RightOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightOne);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, 180, 0);
                LeftOne.transform.localPosition = new Vector3(-7, 0, 0);
                LeftOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftOne);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, 180, 0);
                TOne.transform.localPosition = new Vector3(-7, 0, 0);
                TOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TOne);
                checkOne = false;
            }
        }
        if (gameObject.tag == "Right")
        {
            if (rando == 0)
            {
                GameObject TunOne = Instantiate(tun, transform.position, Quaternion.identity);
                TunOne.transform.position = gameObject.transform.position;
                TunOne.transform.rotation = gameObject.transform.rotation;
                TunOne.transform.parent = gameObject.transform;
                TunOne.transform.Rotate(0, 180, 0);
                TunOne.transform.localPosition = new Vector3(-7, 0, 0);
                TunOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunOne);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, 180, 0);
                RightOne.transform.localPosition = new Vector3(-7, 0, 0);
                RightOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightOne);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, 180, 0);
                LeftOne.transform.localPosition = new Vector3(-7, 0, 0);
                LeftOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftOne);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, 180, 0);
                TOne.transform.localPosition = new Vector3(-7, 0, 0);
                TOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TOne);
                checkOne = false;
            }
        }
        if (gameObject.tag == "Left")
        {
            if (rando == 0)
            {
                GameObject TunOne = Instantiate(tun, transform.position, Quaternion.identity);
                TunOne.transform.position = gameObject.transform.position;
                TunOne.transform.rotation = gameObject.transform.rotation;
                TunOne.transform.parent = gameObject.transform;
                TunOne.transform.Rotate(0, 90, 0);
                TunOne.transform.localPosition = new Vector3(0, 0, 7);
                TunOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunOne);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, 270, 0);
                RightOne.transform.localPosition = new Vector3(0, 0, 7);
                RightOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightOne);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, 270, 0);
                LeftOne.transform.localPosition = new Vector3(0, 0, 7);
                LeftOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftOne);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, 270, 0);
                TOne.transform.localPosition = new Vector3(0, 0, 7);
                TOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TOne);
                checkOne = false;
            }
        }
        if (gameObject.tag == "T")
        {
            if (rando == 0)
            {
                GameObject TunOne = Instantiate(tun, transform.position, Quaternion.identity);
                TunOne.transform.position = gameObject.transform.position;
                TunOne.transform.rotation = gameObject.transform.rotation;
                TunOne.transform.parent = gameObject.transform;
                TunOne.transform.Rotate(0, 0, 0);
                TunOne.transform.localPosition = new Vector3(-7, 0, 0);
                TunOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunOne);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, 180, 0);
                RightOne.transform.localPosition = new Vector3(-7, 0, 0);
                RightOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightOne);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, 180, 0);
                LeftOne.transform.localPosition = new Vector3(-7, 0, 0);
                LeftOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftOne);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, 180, 0);
                TOne.transform.localPosition = new Vector3(-7, 0, 0);
                TOne.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TOne);
                checkOne = false;
            }
        }
    }
    public void CreateNextMazeTwo()
    {
        if (gameObject.tag == "Tunnel")
        {
            if (rando == 0)
            {
                GameObject TunTwo = Instantiate(tun, transform.position, Quaternion.identity);
                TunTwo.transform.position = gameObject.transform.position;
                TunTwo.transform.rotation = gameObject.transform.rotation;
                TunTwo.transform.parent = gameObject.transform;
                TunTwo.transform.localPosition = new Vector3(7, 0, 0);
                TunTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunTwo);
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, 0, 0);
                RightTwo.transform.localPosition = new Vector3(7, 0, 0);
                RightTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightTwo);
                checkTwo = false;
            }
            if (rando == 2)
            {
                GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                LeftTwo.transform.position = gameObject.transform.position;
                LeftTwo.transform.rotation = gameObject.transform.rotation;
                LeftTwo.transform.parent = gameObject.transform;
                LeftTwo.transform.Rotate(0, 0, 0);
                LeftTwo.transform.localPosition = new Vector3(7, 0, 0);
                LeftTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftTwo);
                checkTwo = false;
            }
            if (rando == 3)
            {
                GameObject TTwo = Instantiate(t, transform.position, Quaternion.identity);
                TTwo.transform.position = gameObject.transform.position;
                TTwo.transform.rotation = gameObject.transform.rotation;
                TTwo.transform.parent = gameObject.transform;
                TTwo.transform.Rotate(0, 0, 0);
                TTwo.transform.localPosition = new Vector3(7, 0, 0);
                TTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TTwo);
                checkTwo = false;
            }
        }
        if (gameObject.tag == "Right")
        {
            if (rando == 0)
            {
                GameObject TunTwo = Instantiate(tun, transform.position, Quaternion.identity);
                TunTwo.transform.position = gameObject.transform.position;
                TunTwo.transform.rotation = gameObject.transform.rotation;
                TunTwo.transform.parent = gameObject.transform;
                TunTwo.transform.Rotate(0, 90, 0);
                TunTwo.transform.localPosition = new Vector3(0, 0, -7);
                TunTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunTwo);
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, 90, 0);
                RightTwo.transform.localPosition = new Vector3(0, 0, -7);
                RightTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightTwo);
                checkTwo = false;
            }
            if (rando == 2)
            {
                GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                LeftTwo.transform.position = gameObject.transform.position;
                LeftTwo.transform.rotation = gameObject.transform.rotation;
                LeftTwo.transform.parent = gameObject.transform;
                LeftTwo.transform.Rotate(0, 90, 0);
                LeftTwo.transform.localPosition = new Vector3(0, 0, -7);
                LeftTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftTwo);
                checkTwo = false;
            }
            if (rando == 3)
            {
                GameObject TTwo = Instantiate(t, transform.position, Quaternion.identity);
                TTwo.transform.position = gameObject.transform.position;
                TTwo.transform.rotation = gameObject.transform.rotation;
                TTwo.transform.parent = gameObject.transform;
                TTwo.transform.Rotate(0, 90, 0);
                TTwo.transform.localPosition = new Vector3(0, 0, -7);
                TTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TTwo);
                checkTwo = false;
            }
        }
        if (gameObject.tag == "Left")
        {
            if (rando == 0)
            {
                GameObject TunTwo = Instantiate(tun, transform.position, Quaternion.identity);
                TunTwo.transform.position = gameObject.transform.position;
                TunTwo.transform.rotation = gameObject.transform.rotation;
                TunTwo.transform.parent = gameObject.transform;
                TunTwo.transform.localPosition = new Vector3(-7, 0, 0);
                TunTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunTwo);
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, 180, 0);
                RightTwo.transform.localPosition = new Vector3(-7, 0, 0);
                RightTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightTwo);
                checkTwo = false;
            }
            if (rando == 2)
            {
                GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                LeftTwo.transform.position = gameObject.transform.position;
                LeftTwo.transform.rotation = gameObject.transform.rotation;
                LeftTwo.transform.parent = gameObject.transform;
                LeftTwo.transform.Rotate(0, 180, 0);
                LeftTwo.transform.localPosition = new Vector3(-7, 0, 0);
                LeftTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftTwo);
                checkTwo = false;
            }
            if (rando == 3)
            {
                GameObject TTwo = Instantiate(t, transform.position, Quaternion.identity);
                TTwo.transform.position = gameObject.transform.position;
                TTwo.transform.rotation = gameObject.transform.rotation;
                TTwo.transform.parent = gameObject.transform;
                TTwo.transform.Rotate(0, 180, 0);
                TTwo.transform.localPosition = new Vector3(-7, 0, 0);
                TTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TTwo);
                checkTwo = false;
            }
        }
        if (gameObject.tag == "T")
        {
            if (rando == 0)
            {
                GameObject TunTwo = Instantiate(tun, transform.position, Quaternion.identity);
                TunTwo.transform.position = gameObject.transform.position;
                TunTwo.transform.rotation = gameObject.transform.rotation;
                TunTwo.transform.parent = gameObject.transform;
                TunTwo.transform.Rotate(0, 90, 0);
                TunTwo.transform.localPosition = new Vector3(0, 0, 7);
                TunTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunTwo);
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, -90, 0);
                RightTwo.transform.localPosition = new Vector3(0, 0, 7);
                RightTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightTwo);
                checkTwo = false;
            }
            if (rando == 2)
            {
                GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                LeftTwo.transform.position = gameObject.transform.position;
                LeftTwo.transform.rotation = gameObject.transform.rotation;
                LeftTwo.transform.parent = gameObject.transform;
                LeftTwo.transform.Rotate(0, -90, 0);
                LeftTwo.transform.localPosition = new Vector3(0, 0, 7);
                LeftTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftTwo);
                checkTwo = false;
            }
            if (rando == 3)
            {
                GameObject TTwo = Instantiate(t, transform.position, Quaternion.identity);
                TTwo.transform.position = gameObject.transform.position;
                TTwo.transform.rotation = gameObject.transform.rotation;
                TTwo.transform.parent = gameObject.transform;
                TTwo.transform.Rotate(0, -90, 0);
                TTwo.transform.localPosition = new Vector3(0, 0, 7);
                TTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TTwo);
                checkTwo = false;
            }
        }
    }
    public void CreateNextMazeThree()
    {
        if (gameObject.tag == "T")
        {
            if (rando == 0)
            {
                GameObject TunThree = Instantiate(tun, transform.position, Quaternion.identity);
                TunThree.transform.position = gameObject.transform.position;
                TunThree.transform.rotation = gameObject.transform.rotation;
                TunThree.transform.parent = gameObject.transform;
                TunThree.transform.Rotate(0, 90, 0);
                TunThree.transform.localPosition = new Vector3(0, 0, -7);
                TunThree.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TunThree);
                checkThree = false;
            }
            if (rando == 1)
            {
                GameObject RightThree = Instantiate(right, transform.position, Quaternion.identity);
                RightThree.transform.position = gameObject.transform.position;
                RightThree.transform.rotation = gameObject.transform.rotation;
                RightThree.transform.parent = gameObject.transform;
                RightThree.transform.Rotate(0, 90, 0);
                RightThree.transform.localPosition = new Vector3(0, 0, -7);
                RightThree.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(RightThree);
                checkThree = false;
            }
            if (rando == 2)
            {
                GameObject LeftThree = Instantiate(left, transform.position, Quaternion.identity);
                LeftThree.transform.position = gameObject.transform.position;
                LeftThree.transform.rotation = gameObject.transform.rotation;
                LeftThree.transform.parent = gameObject.transform;
                LeftThree.transform.Rotate(0, 90, 0);
                LeftThree.transform.localPosition = new Vector3(0, 0, -7);
                LeftThree.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(LeftThree);
                checkThree = false;
            }
            if (rando == 3)
            {
                GameObject TThree = Instantiate(t, transform.position, Quaternion.identity);
                TThree.transform.position = gameObject.transform.position;
                TThree.transform.rotation = gameObject.transform.rotation;
                TThree.transform.parent = gameObject.transform;
                TThree.transform.Rotate(0, 90, 0);
                TThree.transform.localPosition = new Vector3(0, 0, -7);
                TThree.transform.parent = GameObject.Find("SPawnPArent").transform;
                AddToLists(TThree);
                checkThree = false;
            }
        }
    }
    public void CreateEndMazeOne()
    {
        if (gameObject.tag == "Tunnel")
        {
            GameObject UOne = Instantiate(u, transform.position, Quaternion.identity);
            UOne.transform.position = gameObject.transform.position;
            UOne.transform.rotation = gameObject.transform.rotation;
            UOne.transform.parent = gameObject.transform;
            UOne.transform.Rotate(0, -180, 0);
            UOne.transform.localPosition = new Vector3(-7, 0, 0);
            UOne.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UOne);
            checkOne = false;
        }
        if (gameObject.tag == "Right")
        {
            GameObject UOne = Instantiate(u, transform.position, Quaternion.identity);
            UOne.transform.position = gameObject.transform.position;
            UOne.transform.rotation = gameObject.transform.rotation;
            UOne.transform.parent = gameObject.transform;
            UOne.transform.Rotate(0, 180, 0);
            UOne.transform.localPosition = new Vector3(-7, 0, 0);
            UOne.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UOne);
            checkOne = false;
        }
        if (gameObject.tag == "Left")
        {
            GameObject UOne = Instantiate(u, transform.position, Quaternion.identity);
            UOne.transform.position = gameObject.transform.position;
            UOne.transform.rotation = gameObject.transform.rotation;
            UOne.transform.parent = gameObject.transform;
            UOne.transform.Rotate(0, -90, 0);
            UOne.transform.localPosition = new Vector3(0, 0, 7);
            UOne.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UOne);
            checkOne = false;
        }
        if (gameObject.tag == "T")
        {
            GameObject UOne = Instantiate(u, transform.position, Quaternion.identity);
            UOne.transform.position = gameObject.transform.position;
            UOne.transform.rotation = gameObject.transform.rotation;
            UOne.transform.parent = gameObject.transform;
            UOne.transform.Rotate(0, 180, 0);
            UOne.transform.localPosition = new Vector3(-7, 0, 0);
            UOne.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UOne);
            checkOne = false;
        }
    }
    public void CreateEndMazeTwo()
    {
        if (gameObject.tag == "Tunnel")
        {
            GameObject UTwo = Instantiate(u, transform.position, Quaternion.identity);
            UTwo.transform.position = gameObject.transform.position;
            UTwo.transform.rotation = gameObject.transform.rotation;
            UTwo.transform.parent = gameObject.transform;
            UTwo.transform.localPosition = new Vector3(7, 0, 0);
            UTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UTwo);
            checkTwo = false;
        }
        if (gameObject.tag == "Right")
        {
            GameObject UTwo = Instantiate(u, transform.position, Quaternion.identity);
            UTwo.transform.position = gameObject.transform.position;
            UTwo.transform.rotation = gameObject.transform.rotation;
            UTwo.transform.parent = gameObject.transform;
            UTwo.transform.Rotate(0, 90, 0);
            UTwo.transform.localPosition = new Vector3(0, 0, -7);
            UTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UTwo);
            checkTwo = false;
        }
        if (gameObject.tag == "Left")
        {
            GameObject UTwo = Instantiate(u, transform.position, Quaternion.identity);
            UTwo.transform.position = gameObject.transform.position;
            UTwo.transform.rotation = gameObject.transform.rotation;
            UTwo.transform.parent = gameObject.transform;
            UTwo.transform.Rotate(0, 180, 0);
            UTwo.transform.localPosition = new Vector3(-7, 0, 0);
            UTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UTwo);
            checkTwo = false;
        }
        if (gameObject.tag == "T")
        {
            GameObject UTwo = Instantiate(u, transform.position, Quaternion.identity);
            UTwo.transform.position = gameObject.transform.position;
            UTwo.transform.rotation = gameObject.transform.rotation;
            UTwo.transform.parent = gameObject.transform;
            UTwo.transform.Rotate(0, -90, 0);
            UTwo.transform.localPosition = new Vector3(0, 0, 7);
            UTwo.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UTwo);
            checkTwo = false;
        }
    }
    public void CreateEndMazeThree()
    {
        if (gameObject.tag == "T")
        {
            GameObject UThree = Instantiate(u, transform.position, Quaternion.identity);
            UThree.transform.position = gameObject.transform.position;
            UThree.transform.rotation = gameObject.transform.rotation;
            UThree.transform.parent = gameObject.transform;
            UThree.transform.Rotate(0, 90, 0);
            UThree.transform.localPosition = new Vector3(0, 0, -7);
            UThree.transform.parent = GameObject.Find("SPawnPArent").transform;
            AddToLists(UThree);
            checkThree = false;
        }
    }
        public void DeclairRando()
    {
        rando = Random.Range(0, 4);
    }
    public void AddToLists(GameObject objectToAdd)
    {
        counter.GetComponent<Counter>().CheckForOverlaps(objectToAdd);
    }

}

