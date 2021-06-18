using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{
    public int diceSize = 20;
    public Button rollButton;
    public Text resultText;

    void Start()
    {
        rollButton.onClick.AddListener(RollDice);
    }

    void Update()
    {
        
    }

    void RollDice()
    {
        int result = Random.Range(1, diceSize+1);
        resultText.text = result.ToString();
    }
}
