using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class pointScript : MonoBehaviour
{
    public scoreCount counter;

    void Start()
    {
        singleton.instance.registerPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        counter.upscore(10);
        singleton.instance.signoutPoint();
        Destroy(gameObject);
    }
}
