using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject tun;
    public GameObject left;
    public GameObject right;
    public GameObject t;
    public bool checkOne;
    public bool checkTwo;
    public bool checkThree;
    public float rando;
    public float tRando;
    public bool triggerOneCollided;
    public bool triggerTwoCollided;
    public bool triggerThreeCollided;
    private float startTime;
    public GameObject manager;
    private bool generating;
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
        generating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (generating == true && Time.time > 1)
        {
            if (Time.time > startTime + .25F)
            {
                if (checkOne == true && !triggerOneCollided)
                {
                    manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                    DeclairRando();
                    DeclairTRando();
                    CreateNextMazeOne();
                }
                if (checkTwo == true && !triggerTwoCollided)
                {
                    manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                    DeclairRando();
                    DeclairTRando();
                    CreateNextMazeTwo();
                }
                if (checkThree == true && !triggerThreeCollided)
                {
                    manager.transform.GetComponent<GenerationManager>().generationTime = Time.time;
                    DeclairRando();
                    DeclairTRando();
                    CreateNextMazeThree();
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
                TunOne.transform.localPosition = new Vector3(-7, 0, 0);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, -90, 0);
                RightOne.transform.localPosition = new Vector3(-8, 0, -4);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, -180, 0);
                LeftOne.transform.localPosition = new Vector3(-4, 0, -5);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, -180, 0);
                TOne.transform.localPosition = new Vector3(-4, 0, -5);
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
                TunOne.transform.Rotate(0, 90, 0);
                TunOne.transform.localPosition = new Vector3(4, 0, -8);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, 180, 0);
                RightOne.transform.localPosition = new Vector3(3, 0, -12);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, 90, 0);
                LeftOne.transform.localPosition = new Vector3(4, 0, -8);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, 90, 0);
                TOne.transform.localPosition = new Vector3(4, 0, -8);
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
                TunOne.transform.localPosition = new Vector3(4, 0, 6);
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, 0, 0);
                RightOne.transform.localPosition = new Vector3(0, 0, 7);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, 270, 0);
                LeftOne.transform.localPosition = new Vector3(-1, 0, 3);
                checkOne = false;
            }
            if (rando == 3)
            {
                GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                TOne.transform.position = gameObject.transform.position;
                TOne.transform.rotation = gameObject.transform.rotation;
                TOne.transform.parent = gameObject.transform;
                TOne.transform.Rotate(0, 270, 0);
                TOne.transform.localPosition = new Vector3(-1, 0, 3);
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
                checkOne = false;
            }
            if (rando == 1)
            {
                GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                RightOne.transform.position = gameObject.transform.position;
                RightOne.transform.rotation = gameObject.transform.rotation;
                RightOne.transform.parent = gameObject.transform;
                RightOne.transform.Rotate(0, -90, 0);
                RightOne.transform.localPosition = new Vector3(-8, 0, -4);
                checkOne = false;
            }
            if (rando == 2)
            {
                GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                LeftOne.transform.position = gameObject.transform.position;
                LeftOne.transform.rotation = gameObject.transform.rotation;
                LeftOne.transform.parent = gameObject.transform;
                LeftOne.transform.Rotate(0, -180, 0);
                LeftOne.transform.localPosition = new Vector3(-4, 0, -5);
                checkOne = false;
            }
            if (rando == 3)
            {
                if (tRando == 0)
                {
                    GameObject TOne = Instantiate(t, transform.position, Quaternion.identity);
                    TOne.transform.position = gameObject.transform.position;
                    TOne.transform.rotation = gameObject.transform.rotation;
                    TOne.transform.parent = gameObject.transform;
                    TOne.transform.Rotate(0, 180, 0);
                    TOne.transform.localPosition = new Vector3(-4, 0, -5);
                    checkOne = false;
                }
                if (tRando == 1)
                {
                    GameObject RightOne = Instantiate(right, transform.position, Quaternion.identity);
                    RightOne.transform.position = gameObject.transform.position;
                    RightOne.transform.rotation = gameObject.transform.rotation;
                    RightOne.transform.parent = gameObject.transform;
                    RightOne.transform.Rotate(0, -90, 0);
                    RightOne.transform.localPosition = new Vector3(-8, 0, -4);
                    checkOne = false;
                }
                if (tRando == 2)
                {
                    GameObject LeftOne = Instantiate(left, transform.position, Quaternion.identity);
                    LeftOne.transform.position = gameObject.transform.position;
                    LeftOne.transform.rotation = gameObject.transform.rotation;
                    LeftOne.transform.parent = gameObject.transform;
                    LeftOne.transform.Rotate(0, -180, 0);
                    LeftOne.transform.localPosition = new Vector3(-4, 0, -5);
                    checkOne = false;
                }
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
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, 90, 0);
                RightTwo.transform.localPosition = new Vector3(11, 0, -1);
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
                TunTwo.transform.localPosition = new Vector3(7, 0, 0);
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, 90, 0);
                RightTwo.transform.localPosition = new Vector3(11, 0, -1);
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
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, -90, 0);
                RightTwo.transform.localPosition = new Vector3(-8, 0, -4);
                checkTwo = false;
            }
            if (rando == 2)
            {
                GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                LeftTwo.transform.position = gameObject.transform.position;
                LeftTwo.transform.rotation = gameObject.transform.rotation;
                LeftTwo.transform.parent = gameObject.transform;
                LeftTwo.transform.Rotate(0, 180, 0);
                LeftTwo.transform.localPosition = new Vector3(-4, 0, -5);
                checkTwo = false;
            }
            if (rando == 3)
            {
                GameObject TTwo = Instantiate(t, transform.position, Quaternion.identity);
                TTwo.transform.position = gameObject.transform.position;
                TTwo.transform.rotation = gameObject.transform.rotation;
                TTwo.transform.parent = gameObject.transform;
                TTwo.transform.Rotate(0, 180, 0);
                TTwo.transform.localPosition = new Vector3(-4, 0, -5);
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
                TunTwo.transform.localPosition = new Vector3(4, 0, 6);
                checkTwo = false;
            }
            if (rando == 1)
            {
                GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                RightTwo.transform.position = gameObject.transform.position;
                RightTwo.transform.rotation = gameObject.transform.rotation;
                RightTwo.transform.parent = gameObject.transform;
                RightTwo.transform.Rotate(0, 0, 0);
                RightTwo.transform.localPosition = new Vector3(0, 0, 7);
                checkTwo = false;
            }
            if (rando == 2)
            {
                GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                LeftTwo.transform.position = gameObject.transform.position;
                LeftTwo.transform.rotation = gameObject.transform.rotation;
                LeftTwo.transform.parent = gameObject.transform;
                LeftTwo.transform.Rotate(0, 180, 0);
                LeftTwo.transform.localPosition = new Vector3(3, 0, 2);
                checkTwo = false;
            }
            if (rando == 3)
            {
                if (tRando == 0)
                {
                    GameObject TTwo = Instantiate(t, transform.position, Quaternion.identity);
                    TTwo.transform.position = gameObject.transform.position;
                    TTwo.transform.rotation = gameObject.transform.rotation;
                    TTwo.transform.parent = gameObject.transform;
                    TTwo.transform.Rotate(0, -90, 0);
                    TTwo.transform.localPosition = new Vector3(-1, 0, 3);
                    checkTwo = false;
                }
                if (tRando == 1)
                {
                    GameObject RightTwo = Instantiate(right, transform.position, Quaternion.identity);
                    RightTwo.transform.position = gameObject.transform.position;
                    RightTwo.transform.rotation = gameObject.transform.rotation;
                    RightTwo.transform.parent = gameObject.transform;
                    RightTwo.transform.Rotate(0, 0, 0);
                    RightTwo.transform.localPosition = new Vector3(0, 0, 7);
                    checkTwo = false;
                }
                if (tRando == 2)
                {
                    GameObject LeftTwo = Instantiate(left, transform.position, Quaternion.identity);
                    LeftTwo.transform.position = gameObject.transform.position;
                    LeftTwo.transform.rotation = gameObject.transform.rotation;
                    LeftTwo.transform.parent = gameObject.transform;
                    LeftTwo.transform.Rotate(0, 180, 0);
                    LeftTwo.transform.localPosition = new Vector3(3, 0, 2);
                    checkTwo = false;
                }
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
                TunThree.transform.Rotate(0, -90, 0);
                TunThree.transform.localPosition = new Vector3(-1, 0, -11);
                checkThree = false;
            }
            if (rando == 1)
            {
                GameObject RightThree = Instantiate(right, transform.position, Quaternion.identity);
                RightThree.transform.position = gameObject.transform.position;
                RightThree.transform.rotation = gameObject.transform.rotation;
                RightThree.transform.parent = gameObject.transform;
                RightThree.transform.Rotate(0, 180, 0);
                RightThree.transform.localPosition = new Vector3(3, 0, -12);
                checkThree = false;
            }
            if (rando == 2)
            {
                GameObject LeftThree = Instantiate(left, transform.position, Quaternion.identity);
                LeftThree.transform.position = gameObject.transform.position;
                LeftThree.transform.rotation = gameObject.transform.rotation;
                LeftThree.transform.parent = gameObject.transform;
                LeftThree.transform.Rotate(0, 90, 0);
                LeftThree.transform.localPosition = new Vector3(4, 0, -8);
                checkThree = false;
            }
            if (rando == 3)
            {
                if (tRando == 0)
                {
                    GameObject TThree = Instantiate(t, transform.position, Quaternion.identity);
                    TThree.transform.position = gameObject.transform.position;
                    TThree.transform.rotation = gameObject.transform.rotation;
                    TThree.transform.parent = gameObject.transform;
                    TThree.transform.Rotate(0, 90, 0);
                    TThree.transform.localPosition = new Vector3(4, 0, -8);
                    checkThree = false;
                }
                if (tRando == 1)
                {
                    GameObject RightThree = Instantiate(right, transform.position, Quaternion.identity);
                    RightThree.transform.position = gameObject.transform.position;
                    RightThree.transform.rotation = gameObject.transform.rotation;
                    RightThree.transform.parent = gameObject.transform;
                    RightThree.transform.Rotate(0, 180, 0);
                    RightThree.transform.localPosition = new Vector3(3, 0, -12);
                    checkThree = false;
                }
                if (tRando == 2)
                {
                    GameObject LeftThree = Instantiate(left, transform.position, Quaternion.identity);
                    LeftThree.transform.position = gameObject.transform.position;
                    LeftThree.transform.rotation = gameObject.transform.rotation;
                    LeftThree.transform.parent = gameObject.transform;
                    LeftThree.transform.Rotate(0, 90, 0);
                    LeftThree.transform.localPosition = new Vector3(4, 0, -8);
                    checkThree = false;
                }
            }
        }
    }
    public void DeclairRando()
    {
        rando = Random.Range(0, 4);
    }
    public void DeclairTRando()
    {
        tRando = Random.Range(0, 3);
    }

}
