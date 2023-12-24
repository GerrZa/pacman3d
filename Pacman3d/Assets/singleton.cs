using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class singleton : MonoBehaviour
{
    public static singleton instance;

    [HideInInspector]
    public int currentPoint = 0;
    public int currentDiffLvl = 0;

    public float currentPowUpTimeLeft = 0f; // current pow up time left
    private float basePowupTimePump = 6f; // base powup pump rate 
    private float currentPumpPowUpTime = 0f; //powup pump rate

    public bool playerPowUp = false;

    public int lastPointValue = 0; // the before registered point
    public int registeredPoint = 0;

    public GameObject pacman = null;

    public int pacLifeLeft = 3;
    public int previousPointRegistered = 0;

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        currentPowUpTimeLeft -= Time.deltaTime;
    }

    private void Update()
    {

        if (previousPointRegistered == 1 && registeredPoint == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (currentPowUpTimeLeft == currentPumpPowUpTime)
        {
            gameEvent.current.powUpOn();
        }
        else if (floorAndCeil(currentPowUpTimeLeft) == 0)
        {
            gameEvent.current.powUpOff();
        }

        if (currentPowUpTimeLeft > 0)
        {
            playerPowUp = true;
        }
        else 
        { 
            playerPowUp = false;
        }

        if (currentDiffLvl < 6)
        {
            currentPumpPowUpTime = basePowupTimePump - (currentDiffLvl * 0.05f);
        }
    }

    float floorAndCeil(float value)
    {
        float baseNumber = Mathf.Floor(value);

        float decimalValue = value - baseNumber;
        if (decimalValue < 0.5)
        {
            return Mathf.Floor(value);
        }
        else
        {
            return Mathf.Ceil(value);
        }
    }
    public void upscore(float amount)
    {
        singleton.instance.currentPoint += 10;
    }

    public void pumpUpPowUp()
    {
        //Debug.Log("pumped");
        currentPowUpTimeLeft = currentPumpPowUpTime;
    }

    public void registerPoint()
    {
        previousPointRegistered = registeredPoint;

        registeredPoint += 1;
    }

    public void signoutPoint()
    {
        previousPointRegistered = registeredPoint;
        registeredPoint -= 1;
    }

    public void resetScore()
    {
        currentPoint = 0;
        pacLifeLeft = 3;
    }

    public void downLife()
    {
        pacLifeLeft -= 1;
        if (pacLifeLeft <= 0) 
        {
            SceneManager.LoadScene("Scenes/gameover");
        }
    }
}
