using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        singleton.instance.pumpUpPowUp();
        Destroy(gameObject);
    }
}
