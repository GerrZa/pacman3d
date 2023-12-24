using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ghostsimplemovement : MonoBehaviour
{
    Rigidbody rb;
    public float baseSpeed = 3.5f;
    public float nerfedSpeed = 2.5f;
    public float currentSpeed = 0f;
    public Vector3 direction = new Vector3(0,0,1);

    [SerializeField] private GameObject weakGhostModel = null;
    [SerializeField] private GameObject baseGhostModel = null;

    [SerializeField] private bool printDebug = false;

    Vector3 initPosition = new Vector3(0,0,0);

    public bool isEatable = false;

    private void Start()
    {
        initPosition = transform.position;

        currentSpeed = baseSpeed;

        rb = GetComponent<Rigidbody>();

        gameEvent.current.onPowUpOn += changeToBlue;
        gameEvent.current.onPowUpOff += backToNormal;
        gameEvent.current.onPacDead += resetGhost;
    }

    private void FixedUpdate()
    {

        rb.velocity = direction * currentSpeed;

        if (printDebug)
        {
            Debug.Log(direction.ToString());
        }

        if (transform.position.x > 12)
        {
            transform.position = new Vector3(-11, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -12)
        {
            transform.position = new Vector3(11, transform.position.y, transform.position.z);
        }
    }
    void changeToBlue()
    {
        isEatable = true;
        currentSpeed = nerfedSpeed;
        weakGhostModel.GetComponent<MeshRenderer>().enabled = true;
        baseGhostModel.GetComponent<MeshRenderer>().enabled = false;
    }

    void backToNormal()
    {
        isEatable = false;
        currentSpeed = baseSpeed;
        weakGhostModel.GetComponent<MeshRenderer>().enabled = false;
        baseGhostModel.GetComponent<MeshRenderer>().enabled = true;
    }

    public void resetGhost()
    {
        transform.position = initPosition;
        backToNormal();
        direction = new Vector3(0, 0, 1);
    }
}
