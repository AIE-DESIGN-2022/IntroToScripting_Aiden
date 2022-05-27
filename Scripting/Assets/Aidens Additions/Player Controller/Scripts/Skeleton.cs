using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    private Vector3 _lastPos;
    private Transform _obj;
    private GameObject _skele;
    public float baseSpeed = 5;
    private float _speed = 5;
    private float _rotation;
    public float sprintMultiplier = 1.5F;
    private float _backWalk = 0.5F;
    private float _lastFire;
    public float fireDelay;
    public bool interacting;
    public bool disguised;
    public GameObject disguise;

    void Start()
    {
        _obj = gameObject.transform;
        _lastPos = _obj.position;
        _skele = _obj.transform.GetChild(0).gameObject;
        _speed = baseSpeed;
        _rotation = _speed * 30;
    }

    void Update()
    {

        //Movement
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 0, z);
        Vector3 rotation = new Vector3(0, x, 0);
        transform.Translate(movement * _speed * Time.deltaTime);
        transform.Rotate(rotation * _rotation * Time.deltaTime);

        //Srint Functionality Stuff
        if (Input.GetAxis("Vertical") < 0)
        {
            _speed = baseSpeed * _backWalk;
        }
        if (Input.GetAxis("Vertical") >= 0)
        {
            _speed = baseSpeed;
        }


        //Sprint
        if (Input.GetAxis("Vertical") < 0)
        {
            
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = baseSpeed * sprintMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = baseSpeed;
        }

        // Animation

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > _lastFire + fireDelay)
                {
                    _skele.GetComponent<Animator>().SetTrigger("Attack");
                    _lastFire = Time.time;
                }
           }
        else
        if (_obj.position != _lastPos)
        {
            _lastPos = _obj.position;
        }
        {

            if (Input.GetAxis("Vertical") > 0)
            {
                _skele.GetComponent<Animator>().SetBool("Walk", true);
            }
            else if (Input.GetAxis("Vertical") <= 0)
            {
                _skele.GetComponent<Animator>().SetBool("Walk", false);
            }
        }
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                _skele.GetComponent<Animator>().SetBool("Back", true);
            }
            else if (Input.GetAxis("Vertical") >= 0)
            {
                _skele.GetComponent<Animator>().SetBool("Back", false);
            }
        }
        if (disguised == true)
        {
            disguise.gameObject.SetActive(true);
        }
        else if (disguised == false)
        {
            disguise.gameObject.SetActive(false);
        }
    }
}

