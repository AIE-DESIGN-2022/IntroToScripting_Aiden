using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
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
    private NavMeshAgent _agent;
    private Transform _target;


    void Start()
    {
        _obj = gameObject.transform;
        _agent = GetComponent<NavMeshAgent>();
        _lastPos = _obj.position;
        _skele = _obj.transform.GetChild(0).gameObject;
        _speed = baseSpeed;
        _rotation = _speed * 50;
    }

    void Update()
    {

        //Movement
        _target = GameObject.FindGameObjectWithTag("Player").transform;


        // Animation

        if (_obj.position == _lastPos)
        {
            _skele.GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        if (_obj.position != _lastPos)
        {
            _skele.GetComponent<Animator>().SetBool("Walk", true);
            _obj.position = _lastPos;
        }
    }
}

