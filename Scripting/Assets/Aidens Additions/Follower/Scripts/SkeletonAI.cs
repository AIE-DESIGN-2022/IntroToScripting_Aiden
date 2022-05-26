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
    public float sprintMultiplier = 1.5F;
    public float fireDelay;


    void Start()
    {
        _obj = gameObject.transform;
        _lastPos = _obj.position;
        _skele = _obj.transform.GetChild(0).gameObject;
    }

    void Update()
    {

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

