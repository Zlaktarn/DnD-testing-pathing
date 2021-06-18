using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiativeTrackerScript : MonoBehaviour
{
    public int diceSize = 20;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RollInitiative()
    {
        int result = Random.Range(1, diceSize + 1);
    }
}
