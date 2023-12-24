using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEvent : MonoBehaviour
{
    public static gameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action onPowUpOn;
    public void powUpOn()
    {
        if (onPowUpOn != null)
        {
            onPowUpOn();
        }
    }

    public event Action onPowUpOff;
    public void powUpOff()
    {
        if (onPowUpOff != null)
        {
            onPowUpOff();
        }
    }

    public event Action onPacDead;
    public void pacDead()
    {
        if (onPacDead != null)
        {
            onPacDead();
        }
    }
}
