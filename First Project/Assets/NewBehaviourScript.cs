using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int maximum = 1000;
        int minimum = 1;


        Debug.Log("Hello friend, welcome to number wizard, Yo");
        Debug.Log("Please a pick a number");
        Debug.Log($"Lowest number you can pick is: {minimum}");
        Debug.Log($"Highest number you can pick is: {maximum}");
        Debug.Log("Tell me if your number is higher or lower than 500");
        Debug.Log("Push up = higher, Push Down = Lower, Push Enter = Corrent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow key was pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow key was pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return key was pressed.");
        }
    }
}
