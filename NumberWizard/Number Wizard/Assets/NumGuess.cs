using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumGuess : MonoBehaviour
{
    
    [SerializeField] int maxNum;
    [SerializeField] int minNum;
    [SerializeField] TextMeshProUGUI displayNum;
    int guessNum;
    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    public void startGame()
    {
        maxNum = maxNum + 1;
        guessANum();
        displayGuessNumber();
    }

    public void onPressHigher()
    {
        if (minNum >= maxNum -1)
        {
            minNum = maxNum - 1;
        }
        else
        {
            minNum = guessNum + 1;
        }
        guessANum();
        displayGuessNumber();
    }

    public void onPressLower()
    {
        if(maxNum <= minNum)
        {
            maxNum = minNum;
        }
        else
        {
            maxNum = guessNum;
        }
        guessANum();
        displayGuessNumber();
    }

    public void guessANum()
    {
        Debug.Log("Min:" + minNum);
        Debug.Log("Max:" + maxNum);
        guessNum = Random.Range(minNum, maxNum);
    }

    public void displayGuessNumber()
    {
        displayNum.text = guessNum.ToString();
    }
    
}
