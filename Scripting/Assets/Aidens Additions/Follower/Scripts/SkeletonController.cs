using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed;
    public float baseSpeed = 5;
    private float _rotationSpeed;
    private Vector3 _moveDirection;
    public float gravity;
    private Vector3 moveRotation;
    public Transform skeleCamera;
    public float _jumpSpeed;
    private Transform _obj;
    private GameObject _skele;
    private float _lastFire;
    public float fireDelay;
    private Vector3 _lastPos;

    void Start()
    {
        _speed = baseSpeed;
        _rotationSpeed = _speed * 0.25F;
        _characterController = GetComponent<CharacterController>();
        _obj = gameObject.transform;
        _lastPos = _obj.position;
        _skele = _obj.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (_characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float moveSpeedX = Input.GetAxis("Vertical") * _speed;
            moveRotation.y += Input.GetAxis("Horizontal") * _rotationSpeed;
            _moveDirection = (forward * moveSpeedX);
        }
        _moveDirection.y -= gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
        moveRotation.y += Input.GetAxis("Horizontal") * _rotationSpeed;
        transform.eulerAngles = new Vector2(0, moveRotation.y);


        //Animation
        if (_obj.position == _lastPos)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > _lastFire + fireDelay)
                {
                    _skele.GetComponent<Animator>().SetTrigger("Attack");
                    _lastFire = Time.time;
                }
            }
        }
        else
        if (_obj.position != _lastPos)
        {
            _lastPos = _obj.position;
        }
        {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _skele.GetComponent<Animator>().SetBool("Walk", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                _skele.GetComponent<Animator>().SetBool("Walk", false);
            }
        }
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                _skele.GetComponent<Animator>().SetBool("Back", true);
            }
            else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                _skele.GetComponent<Animator>().SetBool("Back", false);
            }
        }


    }
}

