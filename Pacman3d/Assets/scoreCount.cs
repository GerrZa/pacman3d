using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreCount : MonoBehaviour
{
    public TextMeshPro textMesh;
    public float score;
    public void upscore(float value)
    {
        singleton.instance.upscore(value);
        textMesh.text = "SCORE : " + singleton.instance.currentPoint.ToString();
    }
}
