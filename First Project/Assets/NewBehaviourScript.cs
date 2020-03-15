using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int maximum;
    public int minimum;
    public int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        int guess = 500;
        int minimum = 1;
        int maximum = 1000;
        Debug.Log("Hello friend, welcome to number wizard, Yo");
        Debug.Log("Please a pick a number");
        Debug.Log($"Lowest number you can pick is: {minimum}");
        Debug.Log($"Highest number you can pick is: {maximum}");
        Debug.Log("Tell me if your number is higher or lower than 500");
        Debug.Log("Push up = higher, Push Down = Lower, Push Enter = Corrent");
        maximum += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minimum = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maximum = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return key was pressed.");
            StartGame();
        }
    }

    void NextGuess()
    {
        guess = (maximum + minimum) / 2;
        Debug.Log($"Is it higher or lower than {guess}");

    }
}
