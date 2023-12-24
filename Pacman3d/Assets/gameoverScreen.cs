using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverScreen : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
        singleton.instance.resetScore();
    }
}
