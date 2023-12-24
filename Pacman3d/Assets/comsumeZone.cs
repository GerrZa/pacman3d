using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comsumeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ghostsimplemovement>().isEatable)
        {
            other.gameObject.GetComponent<ghostsimplemovement>().resetGhost();
            singleton.instance.upscore(200);
        }
        else
        {
            gameEvent.current.pacDead();
        }
    }
}
