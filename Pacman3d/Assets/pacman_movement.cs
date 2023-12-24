using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class pacman_movement : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 10.0f;
    public Vector3 onHoldDirection = new Vector3(0, 0, 0);
    private float onHoldResetTimeStack = 0f;
    private float resetTime = 1.2f;
    public Vector3 goingDirection = new Vector3(0, 0, 0);

    //wallchecker
    public wallchecker upChecker;
    public wallchecker downChecker;
    public wallchecker rightChecker;
    public wallchecker leftChecker;

    [SerializeField] private Transform transCom;
    [SerializeField] private Transform pacAnchor;

    Vector3 initPosition = new Vector3(0,2,-5);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        singleton.instance.pacman = gameObject;

        goingDirection = new Vector3(0, 0, 0);

        gameEvent.current.onPacDead += dead;
    }

    private void FixedUpdate()
    {

        onHoldResetTimeStack += Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            assignDirection(new Vector3(0, 0, 1));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            assignDirection(new Vector3(0, 0, -1));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            assignDirection(new Vector3(1, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            assignDirection(new Vector3(-1, 0, 0));
        }


        if (onHoldResetTimeStack > resetTime)
        {
            onHoldDirection = new Vector3(0, 0, 0);
        }

        rb.velocity = goingDirection * speed;

        if (transform.position.x > 12)
        {
            transform.position = new Vector3(-11, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -12)
        {
            transform.position = new Vector3(11, transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {

        if (onHoldDirection == new Vector3(0, 0, 1) && upChecker.collisionEmpty)
        {
            assignAndResetDirection();
        }
        else if (onHoldDirection == new Vector3(0, 0, -1) && downChecker.collisionEmpty)
        {
            assignAndResetDirection();
        }
        else if (onHoldDirection == new Vector3(1, 0, 0) && rightChecker.collisionEmpty)
        {
            assignAndResetDirection();
        }
        else if (onHoldDirection == new Vector3(-1, 0, 0) && leftChecker.collisionEmpty)
        {
            assignAndResetDirection();
        }

        
    }

    void assignDirection(Vector3 direction)
    {
        onHoldResetTimeStack = 0;

        if (direction != goingDirection)
        {
            onHoldDirection = direction;
        }
    }

    void assignAndResetDirection()
    {
        if (onHoldDirection != -goingDirection)
        {
            simplifiedPos();
        } 
            
        goingDirection = onHoldDirection;

        onHoldDirection = new Vector3(0, 0, 0);

        if (goingDirection == new Vector3(0, 0, 1))
        {
            pacAnchor.rotation = Quaternion.Euler(0,0,0);
        }
        else if (goingDirection == new Vector3(0, 0, -1))
        {
            pacAnchor.rotation = Quaternion.Euler(0,180,0);
        }
        else if (goingDirection == new Vector3(1, 0, 0))
        {
            pacAnchor.rotation = Quaternion.Euler(0,90,0);
        }
        else if (goingDirection == new Vector3(-1, 0, 0))
        {
            pacAnchor.rotation = Quaternion.Euler(0,-90,0);
        }

    }
    
    float floorAndCeil(float value)
    {
        float baseNumber = Mathf.Floor(value);

        float decimalValue = value - baseNumber;
        if (decimalValue < 0.5)
        {
            return Mathf.Floor(value);
        }
        else
        {
            return Mathf.Ceil(value);
        }
    }

    void simplifiedPos()
    {
        transform.position = new Vector3(floorAndCeil(transform.position.x), transform.position.y ,floorAndCeil(transform.position.z));
    }
    void dead()
    {
        singleton.instance.downLife();
        transform.position = new Vector3(0, 2, -5);
        goingDirection = new Vector3(0,0,0);
    }
}
