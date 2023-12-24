using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class turner : MonoBehaviour
{
    public bool isStartPoint = false; // the first turner ghost will approach

    [SerializeField] private bool right;
    [SerializeField] private bool left;
    [SerializeField] private bool up;
    [SerializeField] private bool down;

    List<Vector3> directonList = new List<Vector3>();

    private void Start()
    {
        if (right)
        {
            directonList.Add(new Vector3(1, 0, 0));
        }
        if (left)
        {
            directonList.Add(new Vector3 (-1,0,0));
        }
        if (up)
        {
            directonList.Add(new Vector3(0, 0, 1));
        }
        if (down)
        {
            directonList.Add(new Vector3(0, 0, -1));
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isStartPoint) // Start point \\ the entrance in front of ghost room
        {
            int randomNumber = UnityEngine.Random.Range(0, 2);
            Vector3[] startPointDir = { new Vector3(1, 0, 0), new Vector3(-1, 0, 0) };

            Vector3 chooseDirection = startPointDir[randomNumber];

            other.gameObject.GetComponent<ghostsimplemovement>().direction = chooseDirection;
        }
        else // Normal regular turner
        {

            List<Vector3> choosableDir = new List<Vector3>(); // create list for direction that isn't the opposite of current direction

            for (int i = 0; i < directonList.Count; i++) // filtering direction in the condition above /\
            {
                if (directonList[i] != -other.gameObject.GetComponent<ghostsimplemovement>().direction)
                {
                    choosableDir.Add(directonList[i]);
                }
            }

            int randomways = UnityEngine.Random.Range(0, 4);

            if (randomways > 0)
            {

                if (singleton.instance.pacman.transform.position.x > other.transform.position.x && // right
                    choosableDir.Contains(new Vector3(1, 0, 0)))
                {
                    other.gameObject.GetComponent<ghostsimplemovement>().direction = new Vector3(1, 0, 0);
                }
                else if (singleton.instance.pacman.transform.position.x < other.transform.position.x && // left
                    choosableDir.Contains(new Vector3(-1, 0, 0)))
                {
                    other.gameObject.GetComponent<ghostsimplemovement>().direction = new Vector3(-1, 0, 0);
                }
                else if (singleton.instance.pacman.transform.position.z < other.transform.position.z && // down
                    choosableDir.Contains(new Vector3(0, 0, -1)))
                {
                    other.gameObject.GetComponent<ghostsimplemovement>().direction = new Vector3(0, 0, -1);
                }
                else if (singleton.instance.pacman.transform.position.z > other.transform.position.z && // up
                    choosableDir.Contains(new Vector3(0, 0, 1)))
                {
                    other.gameObject.GetComponent<ghostsimplemovement>().direction = new Vector3(0, 0, 1);
                }
                else
                {
                    int randomNumber = UnityEngine.Random.Range(0, choosableDir.Count);

                    other.gameObject.GetComponent<ghostsimplemovement>().direction = choosableDir[randomNumber];
                }
            }

            else // powup phase i guess?
            {

                int randomNumber = UnityEngine.Random.Range(0, choosableDir.Count);

                other.gameObject.GetComponent<ghostsimplemovement>().direction = choosableDir[randomNumber];

            }
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

    Vector3 pushVector(Vector3 value)
    {
        Vector3 returnVector3 = Vector3.zero;
        returnVector3.x = floorAndCeil(value.x);
        returnVector3.z = floorAndCeil(value.z);

        return returnVector3;
    }

    
}
