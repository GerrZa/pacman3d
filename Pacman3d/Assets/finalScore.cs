using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score : " + singleton.instance.currentPoint.ToString();
    }
}
