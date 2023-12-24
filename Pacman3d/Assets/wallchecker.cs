using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wallchecker : MonoBehaviour
{

    int colliderCount = 0;
    [HideInInspector] public bool collisionEmpty = false;
    [SerializeField] private bool printDebug = false;

    private void FixedUpdate()
    {

        if (printDebug)
        {
            Debug.Log(collisionEmpty);
        }
        collisionEmpty = (colliderCount <= 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        colliderCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        colliderCount--;
    }
}
