using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenwarp : MonoBehaviour
{

    [SerializeField] public screenwarp anotherWarp;
    [HideInInspector] public bool canWarp = true;
    
    private void OnTriggerEnter(Collider other)
    {

        if (canWarp)
        {
            anotherWarp.canWarp = false;
            other.gameObject.transform.position = anotherWarp.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canWarp = true;
    }
}
