using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeLeftUI : MonoBehaviour
{
    [SerializeField] MeshRenderer pacLife1;
    [SerializeField] MeshRenderer pacLife2;
    [SerializeField] MeshRenderer pacLife3;

    private void Update()
    {
        if (singleton.instance.pacLifeLeft == 3)
        {
            pacLife1.enabled = true;
            pacLife2.enabled = true;
            pacLife3.enabled = true;
        }
        else if (singleton.instance.pacLifeLeft == 2)
        {
            pacLife1.enabled = true;
            pacLife2.enabled = true;
            pacLife3.enabled = false;
        }
        else if (singleton.instance.pacLifeLeft == 1)
        {
            pacLife1.enabled = true;
            pacLife2.enabled = false;
            pacLife3.enabled = false;
        }
        else
        {
            pacLife1.enabled =false;
            pacLife2.enabled =false;
            pacLife3.enabled =false;
        }
    }
}
